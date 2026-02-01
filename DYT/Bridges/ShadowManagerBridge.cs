using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using DYT.Bridges;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace DYT
{
    public class ShadowManagerBridge : MonoBehaviour
    {
        public Texture shadowTexture;
        
        public void SetTexture(string texturePath)
        {
            string filePath = GameLaunch.GetFilePath(texturePath);
            // byte[] textureData = File.ReadAllBytes(filePath);
            // Texture2D texture = new Texture2D(2, 2);
            // texture.LoadImage(textureData);
            // Texture2D texture = ConvertKTexToPNG(filePath);
            // shadowTexture = texture;
            ConvertAtlas(filePath);
        }
        
        /// <summary>
        /// 将KTEX格式转换为PNG Texture2D
        /// </summary>
        private Texture2D ConvertKTexToPNG(string ktexFilePath)
        {
            byte[] ktexData = File.ReadAllBytes(ktexFilePath);
            
            // 验证KTEX头部
            if (ktexData.Length < 4 || 
                ktexData[0] != 'K' || ktexData[1] != 'T' || 
                ktexData[2] != 'E' || ktexData[3] != 'X')
            {
                Debug.LogError("不是有效的KTEX文件格式");
                return null;
            }

            // KTEX文件结构解析
            // 偏移4: 平台标识 (2字节)
            // 偏移6: 像素格式 (2字节)
            // 偏移8: 纹理类型 (2字节)
            // 偏移10: mipmap数量 (2字节)
            // 偏移12: 标志 (2字节)
            // 偏移14: 剩余部分 (2字节)
            
            int offset = 16; // 头部大小
            
            // 读取mipmap信息
            int numMipmaps = BitConverter.ToUInt16(ktexData, 10);
            
            // 每个mipmap有16字节的信息
            List<MipmapInfo> mipmaps = new List<MipmapInfo>();
            for (int i = 0; i < numMipmaps; i++)
            {
                int mipOffset = offset + i * 16;
                MipmapInfo mip = new MipmapInfo
                {
                    width = BitConverter.ToUInt16(ktexData, mipOffset),
                    height = BitConverter.ToUInt16(ktexData, mipOffset + 2),
                    pitch = BitConverter.ToUInt16(ktexData, mipOffset + 4),
                    dataSize = BitConverter.ToInt32(ktexData, mipOffset + 8)
                };
                mipmaps.Add(mip);
            }

            // 跳过mipmap头部信息
            offset += numMipmaps * 16;

            MipmapInfo mainMip = mipmaps[0];
            
            // 提取像素数据
            byte[] pixelData = new byte[mainMip.dataSize];
            Array.Copy(ktexData, offset, pixelData, 0, mainMip.dataSize);

            // 解压DXT压缩（如果需要）
            // 饥荒通常使用DXT5格式
            Texture2D texture = new Texture2D(mainMip.width, mainMip.height, TextureFormat.DXT5, false);
            texture.LoadRawTextureData(pixelData);
            texture.Apply();

            return texture;
        }
        
        private void ConvertAtlas(string texPath)
        {
            string toolPath = $"{Application.persistentDataPath}/dst-mod-tool.exe";
            string pngPath = Path.ChangeExtension(texPath, ".png");

            // 调用 dst-mod-tool 转换 TEX → PNG
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = toolPath,
                Arguments = $"{texPath} {pngPath} --unpacktex",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            using (Process process = Process.Start(processStartInfo))
            {
                string readToEnd = process.StandardOutput.ReadToEnd();
                string readToEndError = process.StandardError.ReadToEnd();
                
                process.WaitForExit(10000); // 10s 超时
            }

            // 加载 PNG 为 Texture2D
            byte[] pngBytes = File.ReadAllBytes(pngPath);
            Texture2D atlasTex = new Texture2D(2, 2);
            atlasTex.LoadImage(pngBytes);
            shadowTexture = atlasTex;

            /*
            // 解析 XML
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNodeList elements = doc.SelectNodes("//Element");
            if (elements.Count == 0)
            {
                EditorUtility.ClearProgressBar();
                EditorUtility.DisplayDialog("错误", "XML 中无 Elements！", "OK");
                DestroyImmediate(atlasTex);
                return;
            }

            // 输出路径
            string fullOutput = Path.Combine(Application.dataPath, outputFolder.Replace('/', Path.DirectorySeparatorChar));
            Directory.CreateDirectory(fullOutput);
            string spritesSubDir = Path.Combine(fullOutput, "individual_sprites");
            Directory.CreateDirectory(spritesSubDir);
            string spritesSubDirUnity = outputFolder + "/individual_sprites"; // Assets 相对

            List<string> spritePaths = new List<string>();
            int w = atlasTex.width;
            int h = atlasTex.height;
            float progress = 0.5f;

            foreach (XmlNode el in elements)
            {
                string name = el.Attributes["name"].Value.Replace(".tex", "");
                float u1 = float.Parse(el.Attributes["u1"].Value);
                float u2 = float.Parse(el.Attributes["u2"].Value);
                float v1 = float.Parse(el.Attributes["v1"].Value);
                float v2 = float.Parse(el.Attributes["v2"].Value);

                int x = Mathf.RoundToInt(u1 * w);
                int width = Mathf.RoundToInt((u2 - u1) * w);
                int y = Mathf.RoundToInt(v1 * h); // v1 为底部，Texture2D y=0 为底
                int height = Mathf.RoundToInt((v2 - v1) * h);

                Color[] pixels = atlasTex.GetPixels(x, y, width, height);
                Texture2D subTex = new Texture2D(width, height, TextureFormat.RGBA32, false);
                subTex.SetPixels(pixels);
                subTex.Apply();

                // 保存为 PNG
                byte[] subPng = subTex.EncodeToPNG();
                string spritePathUnity = spritesSubDirUnity + "/" + name + ".png";
                string fullSpritePath = Path.Combine(spritesSubDir, name + ".png");
                File.WriteAllBytes(fullSpritePath, subPng);
                spritePaths.Add(spritePathUnity);

                // 导入并设置 Sprite Import Settings
                AssetDatabase.ImportAsset(spritePathUnity);
                TextureImporter ti = AssetImporter.GetAtPath(spritePathUnity) as TextureImporter;
                if (ti != null)
                {
                    ti.spriteImportMode = SpriteImportMode.Single;
                    ti.spritePivot = new Vector2(0.5f, 0f); // DS 风格：底部中心
                    ti.textureType = TextureImporterType.Sprite;
                    ti.mipmapEnabled = false;
                    ti.filterMode = FilterMode.Point; // 像素艺术无滤镜
                    ti.wrapMode = TextureWrapMode.Clamp;
                    ti.SaveAndReimport();
                }

                DestroyImmediate(subTex);
                progress += 0.3f / elements.Count;
                EditorUtility.DisplayProgressBar("转换中...", $"裁剪 Sprite: {name}", progress);
            }

            DestroyImmediate(atlasTex);

            // 创建 Sprite Atlas
            string atlasName = Path.GetFileNameWithoutExtension(xmlPath);
            string atlasPath = outputFolder + "/" + atlasName + ".spriteatlas";
            SpriteAtlas spriteAtlas = AssetDatabase.LoadAssetAtPath<SpriteAtlas>(atlasPath);
            if (spriteAtlas == null)
            {
                spriteAtlas = ScriptableObject.CreateInstance<SpriteAtlas>();
                AssetDatabase.CreateAsset(spriteAtlas, atlasPath);
            }

            // 添加所有 Sprites 到 Atlas
            Object[] allObjs = AssetDatabase.LoadAllAssetsAtPath(spritesSubDirUnity);
            foreach (Object obj in allObjs)
            {
                if (obj is Sprite)
                    spriteAtlas.SetObjectToPack(obj);
            }

            // 设置 Packing
            PackingSettings packSettings = new PackingSettings(4096, 4096, 2, 4096, false, true, 150, SpriteAtlasType.Sprite);
            spriteAtlas.SetPackingSettings(packSettings);
            TightPackingSettings tightSettings = new TightPackingSettings(false, false);
            spriteAtlas.SetTightPackingSettings(tightSettings);

            // 预览打包
            spriteAtlas.PackPreview();
            EditorUtility.SetDirty(spriteAtlas);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            // 清理临时 PNG
            try { File.Delete(pngPath); } catch { }

            Debug.Log($"转换完成: {elements.Count} 个 Sprites → {atlasPath}");
            */
        }
          
        /// <summary>
        /// 根据XML文件切割图集
        /// </summary>
        private void SliceTextureAtlas(Texture2D texture, string xmlFilePath, string texturePath)
        {
            try
            {
                // 1. 保存PNG到Assets目录
                string assetPath = SaveTextureAsAsset(texture, texturePath);
                if (string.IsNullOrEmpty(assetPath))
                {
                    Debug.LogError("保存纹理失败");
                    return;
                }

                // 2. 解析XML获取切割信息
                List<SpriteMetaData> spriteSheet = ParseAtlasXML(xmlFilePath, texture.width, texture.height);
                
                // 3. 设置TextureImporter
                TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;
                if (importer != null)
                {
                    importer.textureType = TextureImporterType.Sprite;
                    importer.spriteImportMode = SpriteImportMode.Multiple;
                    importer.spritesheet = spriteSheet.ToArray();
                    importer.mipmapEnabled = false;
                    importer.filterMode = FilterMode.Bilinear;
                    importer.textureCompression = TextureImporterCompression.Uncompressed;
                    
                    AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
                    Debug.Log($"成功切割图集: {assetPath}, 共 {spriteSheet.Count} 个sprite");
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"切割图集时出错: {e.Message}\n{e.StackTrace}");
            }
        }
        
        /// <summary>
        /// 保存纹理为PNG资源
        /// </summary>
        private string SaveTextureAsAsset(Texture2D texture, string originalPath)
        {
            // 创建保存目录
            string savePath = "Assets/ImportedTextures/";
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            // 生成文件名
            string fileName = Path.GetFileNameWithoutExtension(originalPath) + ".png";
            string fullPath = savePath + fileName;

            // 编码为PNG
            byte[] pngData = texture.EncodeToPNG();
            File.WriteAllBytes(fullPath, pngData);
            
            AssetDatabase.Refresh();
            return fullPath;
        }

        /// <summary>
        /// 解析Atlas XML文件
        /// </summary>
        private List<SpriteMetaData> ParseAtlasXML(string xmlFilePath, int textureWidth, int textureHeight)
        {
            List<SpriteMetaData> sprites = new List<SpriteMetaData>();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);

                XmlNodeList elements = xmlDoc.SelectNodes("//Element");
                
                foreach (XmlNode element in elements)
                {
                    string name = element.Attributes["name"]?.Value;
                    if (string.IsNullOrEmpty(name))
                        continue;

                    // 移除.tex后缀
                    name = name.Replace(".tex", "");

                    // 读取UV坐标 (0-1范围)
                    float u1 = float.Parse(element.Attributes["u1"].Value);
                    float u2 = float.Parse(element.Attributes["u2"].Value);
                    float v1 = float.Parse(element.Attributes["v1"].Value);
                    float v2 = float.Parse(element.Attributes["v2"].Value);

                    // 转换为像素坐标
                    // 注意：饥荒的V坐标是从上到下，Unity是从下到上，需要翻转
                    float x = u1 * textureWidth;
                    float y = (1 - v2) * textureHeight; // 翻转V坐标
                    float width = (u2 - u1) * textureWidth;
                    float height = (v2 - v1) * textureHeight;

                    SpriteMetaData sprite = new SpriteMetaData
                    {
                        name = name,
                        rect = new Rect(x, y, width, height),
                        alignment = (int)SpriteAlignment.Center,
                        pivot = new Vector2(0.5f, 0.5f)
                    };

                    sprites.Add(sprite);
                }

                Debug.Log($"从XML解析出 {sprites.Count} 个sprite定义");
            }
            catch (Exception e)
            {
                Debug.LogError($"解析XML文件时出错: {e.Message}\n{e.StackTrace}");
            }

            return sprites;
        }
    }
}