using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TMPro;
using Unity.SharpZipLib.Zip;
using UnityEngine;
using UnityEngine.TextCore;
using Debug = UnityEngine.Debug;

namespace DYT.Bridges
{
    /// <summary>
    /// 字体管理系统 - 集成Unity的TextMeshPro字体系统
    /// 支持字体加载、卸载、备用字体设置、字符宽度调整等功能
    /// </summary>
    public class FontBridge : MonoBehaviour
    {
        public static FontBridge Instance;

        // 字体别名 -> TMP_FontAsset 的映射
        public readonly Dictionary<string, TMP_FontAsset> _loadedFonts = 
            new Dictionary<string, TMP_FontAsset>(StringComparer.OrdinalIgnoreCase);

        // 字体别名 -> 备用字体列表 的映射
        private readonly Dictionary<string, List<TMP_FontAsset>> _fontFallbacks = 
            new Dictionary<string, List<TMP_FontAsset>>(StringComparer.OrdinalIgnoreCase);

        // 字体别名 -> 字符宽度调整值 的映射
        private readonly Dictionary<string, float> _fontAdvanceAdjustments = 
            new Dictionary<string, float>(StringComparer.OrdinalIgnoreCase);

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// 加载字体文件并注册别名
        /// </summary>
        public void LoadFont(string filename, string alias)
        {
            string filePath = GameLaunch.GetFilePath(filename);

            using FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using ZipFile zipFile = new ZipFile(fileStream);
            byte[] texBytes = { };
            string fnt = null;
            foreach (ZipEntry zipEntry in zipFile)
            {
                Stream inputStream = zipFile.GetInputStream(zipEntry);
                
                // 使用 MemoryStream 读取流内容，避免直接访问 Length 导致的异常
                using MemoryStream ms = new MemoryStream();
                
                byte[] buffer = new byte[4096];
                int count;
                while ((count = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, count);
                }
                        
                byte[] data = ms.ToArray();

                if (zipEntry.Name.EndsWith(".tex"))
                {
                    texBytes = data;
                }
                else if (zipEntry.Name.EndsWith(".fnt"))
                {
                    // 正确转换字节数组为字符串，处理潜在的 BOM 头
                    fnt = Encoding.UTF8.GetString(data);
                }
            }
            
            // 验证KTEX头部
            if (texBytes.Length < 4 || 
                texBytes[0] != 'K' || texBytes[1] != 'T' || 
                texBytes[2] != 'E' || texBytes[3] != 'X')
            {
                Debug.LogError("不是有效的KTEX文件格式");
            }

            // KTEX文件结构解析
            // 平台标识、像素格式、纹理类型、mipmap数量、标志、剩余部分
            
            int offset = 8; // 头部大小
            
            // 每个mipmap有16字节的信息
            MipmapInfo mainMipmapInfo = null;
            TextureFormat textureFormat = TextureFormat.DXT5;
            while (true)
            {
                MipmapInfo mipmapInfo = new MipmapInfo
                {
                    width = BitConverter.ToUInt16(texBytes, offset),
                    height = BitConverter.ToUInt16(texBytes, offset + 2),
                    pitch = BitConverter.ToUInt16(texBytes, offset + 4),
                    dataSize = BitConverter.ToInt32(texBytes, offset + 6)
                };

                offset += 10;

                if (mainMipmapInfo == null)
                {
                    mainMipmapInfo = mipmapInfo;
                    
                    if (mipmapInfo.width * mipmapInfo.height == mipmapInfo.dataSize)
                    {
                        textureFormat = TextureFormat.DXT5;
                    }
                    else if (mipmapInfo.width * mipmapInfo.height * 4 == mipmapInfo.dataSize)
                    {
                        textureFormat = TextureFormat.RGBA32;
                        break;
                    }
                }

                if (mipmapInfo.width == 1 && mipmapInfo.height == 1)
                {
                    break;
                }
            }
            
            // 提取像素数据
            byte[] pixelData = new byte[mainMipmapInfo.dataSize];
            Array.Copy(texBytes, offset, pixelData, 0, mainMipmapInfo.dataSize);

            // 解压DXT压缩（如果需要）
            // 饥荒通常使用DXT5格式
            Texture2D texture = new Texture2D(
                mainMipmapInfo.width, mainMipmapInfo.height, textureFormat, false
            );
            texture.LoadRawTextureData(pixelData);
            texture.Apply();
            
            CustomFntParse customFntParse = CustomFntParse.GetFntParse(fnt);
            
            // 1. 创建实例
            TMP_FontAsset fontAsset = ScriptableObject.CreateInstance<TMP_FontAsset>();
            fontAsset.name = customFntParse.fontName;

            // 2. 解析 XML
            string fontName = customFntParse.fontName;
            int scaleW = customFntParse.textureWidth;
            int scaleH = customFntParse.textureHeight;
            float lineHeight = customFntParse.lineHeight;
            float size = customFntParse.fontSize;
            
            // 加载 PNG 为 Texture2D
            Texture2D fontTexture = new Texture2D(scaleW, scaleH);
            fontTexture.LoadImage(texBytes);

            // 设置 FaceInfo
            FaceInfo faceInfo = new FaceInfo
            {
                familyName = fontName,
                pointSize = (int)size,
                lineHeight = lineHeight,
                ascentLine = float.Parse(customFntParse.lineBaseHeight.ToString())
            };
            faceInfo.baseline = faceInfo.ascentLine;
            faceInfo.scale = 1.0f;
            fontAsset.faceInfo = faceInfo;

            FieldInfo versionField = typeof(TMP_FontAsset).GetField(
                "m_Version", BindingFlags.NonPublic | BindingFlags.Instance);
            if (versionField != null) versionField.SetValue(fontAsset, "1.1.0");
            
            // 4. 配置资源
            fontAsset.atlasTextures = new[] { fontTexture };
            FieldInfo atlasWidth = typeof(TMP_FontAsset).GetField(
                "m_AtlasWidth", BindingFlags.NonPublic | BindingFlags.Instance);
            if (atlasWidth != null) atlasWidth.SetValue(fontAsset, scaleW);
            FieldInfo atlasHeight = typeof(TMP_FontAsset).GetField(
                "m_AtlasHeight", BindingFlags.NonPublic | BindingFlags.Instance);
            if (atlasHeight != null) atlasHeight.SetValue(fontAsset, scaleH);
            
            Shader bitmapShader = Shader.Find("TextMeshPro/Bitmap");
            Material fontMaterial = new Material(bitmapShader);
            fontMaterial.name = fontName + " Material";
            fontMaterial.mainTexture = fontTexture;
            fontAsset.material = fontMaterial;

            // 3. 填充字形和字符
            foreach (RawCharacterInfo rawCharacterInfo in customFntParse.rawCharInfos)
            {
                uint id = uint.Parse(rawCharacterInfo.ID.ToString());
                float x = float.Parse(rawCharacterInfo.X.ToString());
                float y = float.Parse(rawCharacterInfo.Y.ToString());
                float width = float.Parse(rawCharacterInfo.Width.ToString());
                float height = float.Parse(rawCharacterInfo.Height.ToString());
                float xoffset = float.Parse(rawCharacterInfo.Xoffset.ToString());
                float yoffset = float.Parse(rawCharacterInfo.Yoffset.ToString());
                float xadvance = float.Parse(rawCharacterInfo.Xadvance.ToString());

                float yInUnity = scaleH - y - height;

                var metrics = new GlyphMetrics(width, height, xoffset, -yoffset, xadvance);
                var rect = new GlyphRect((int)x, (int)yInUnity, (int)width, (int)height);
                var glyph = new Glyph(id, metrics, rect, 1.0f, 0);
            
                fontAsset.glyphTable.Add(glyph);
                fontAsset.characterTable.Add(new TMP_Character(id, glyph));
            }
            
            fontAsset.ReadFontAssetDefinition();
            
            _loadedFonts[alias] = fontAsset;
        }

        /// <summary>
        /// 卸载字体
        /// </summary>
        public void UnloadFont(string alias)
        {
            if (string.IsNullOrEmpty(alias))
            {
                Debug.LogWarning("[FontManager] UnloadFont: alias is empty");
                return;
            }

            try
            {
                if (_loadedFonts.ContainsKey(alias))
                {
                    _loadedFonts.Remove(alias);
                    _fontFallbacks.Remove(alias);
                    _fontAdvanceAdjustments.Remove(alias);
                    Debug.Log($"[FontManager] Font unloaded: {alias}");
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"[FontManager] UnloadFont('{alias}') error: {e.Message}");
            }
        }

        /// <summary>
        /// 设置字体的备用字体列表
        /// </summary>
        public void SetupFontFallbacks(string alias, string fallbacksStr)
        {
            if (string.IsNullOrEmpty(alias) || string.IsNullOrEmpty(fallbacksStr))
            {
                Debug.LogWarning(
                    "FontManager.cs -> SetupFontFallbacks() " +
                    $"-> alias='{alias}', fallback='{fallbacksStr}'"
                );
                return;
            }

            try
            {
                if (!_loadedFonts.ContainsKey(alias))
                {
                    Debug.LogWarning($"[FontManager] Font '{alias}' not loaded, cannot setup fallbacks");
                    return;
                }

                TMP_FontAsset mainFont = _loadedFonts[alias];
                List<TMP_FontAsset> fallbackList = new List<TMP_FontAsset>();

                // 解析备用字体列表（逗号分隔）
                string[] fallbackNames = fallbacksStr.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
                
                foreach (string fallbackName in fallbackNames)
                {
                    string trimmedName = fallbackName.Trim();
                    if (_loadedFonts.TryGetValue(trimmedName, out TMP_FontAsset fallbackFont))
                    {
                        fallbackList.Add(fallbackFont);
                    }
                    else
                    {
                        Debug.LogWarning($"[FontManager] Fallback font '{trimmedName}' not found");
                    }
                }

                if (fallbackList.Count > 0)
                {
                    _fontFallbacks[alias] = fallbackList;
                    
                    // 应用到TMP_FontAsset
                    if (mainFont.fallbackFontAssetTable == null)
                    {
                        mainFont.fallbackFontAssetTable = new List<TMP_FontAsset>();
                    }
                    mainFont.fallbackFontAssetTable.Clear();
                    mainFont.fallbackFontAssetTable.AddRange(fallbackList);
                    
                    Debug.Log($"[FontManager] Font fallbacks setup: {alias} -> {string.Join(", ", fallbackNames)}");
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"[FontManager] SetupFontFallbacks('{alias}', '{fallbacksStr}') error: {e.Message}");
            }
        }

        /// <summary>
        /// 调整字体的字符宽度
        /// </summary>
        public void AdjustFontAdvance(string alias, float advance)
        {
            if (string.IsNullOrEmpty(alias))
            {
                Debug.LogWarning("[FontManager] AdjustFontAdvance: alias is empty");
                return;
            }

            try
            {
                if (!_loadedFonts.ContainsKey(alias))
                {
                    Debug.LogWarning($"[FontManager] Font '{alias}' not loaded");
                    return;
                }

                _fontAdvanceAdjustments[alias] = advance;
                Debug.LogWarning(
                    "FontManager.cs -> AdjustFontAdvance() " +
                    $"-> alias='{alias}', advance='{advance}'"
                );
                
                // 这里可以应用到具体的字体资源
                // 实际应用取决于TMP_FontAsset的具体实现
            }
            catch (Exception e)
            {
                Debug.LogError($"[FontManager] AdjustFontAdvance('{alias}', {advance}) error: {e.Message}");
            }
        }

        /// <summary>
        /// 获取已���载的字体
        /// </summary>
        public TMP_FontAsset GetFont(string alias)
        {
            if (string.IsNullOrEmpty(alias))
                return null;

            _loadedFonts.TryGetValue(alias, out TMP_FontAsset font);
            return font;
        }

        /// <summary>
        /// 检查字体是否已加载
        /// </summary>
        public bool IsFontLoaded(string alias)
        {
            return !string.IsNullOrEmpty(alias) && _loadedFonts.ContainsKey(alias);
        }

        /// <summary>
        /// 获取字体的备用字体列表
        /// </summary>
        public List<TMP_FontAsset> GetFontFallbacks(string alias)
        {
            if (string.IsNullOrEmpty(alias))
                return null;

            _fontFallbacks.TryGetValue(alias, out List<TMP_FontAsset> fallbacks);
            return fallbacks;
        }

        /// <summary>
        /// 获取字体的字符宽度调整值
        /// </summary>
        public float GetFontAdvanceAdjustment(string alias)
        {
            if (string.IsNullOrEmpty(alias))
                return 0f;

            _fontAdvanceAdjustments.TryGetValue(alias, out float adjustment);
            return adjustment;
        }

        /// <summary>
        /// 卸载所有字体
        /// </summary>
        public void UnloadAllFonts()
        {
            _loadedFonts.Clear();
            _fontFallbacks.Clear();
            _fontAdvanceAdjustments.Clear();
            Debug.Log("[FontManager] All fonts unloaded");
        }

        /// <summary>
        /// 加载字体资源的核心方法
        /// </summary>
        private TMP_FontAsset LoadFontAsset(string filename, string alias)
        {
            // 方案5: 从persistentDataPath加载
            string persistentPath = Path.Combine(Application.persistentDataPath, filename);
            if (File.Exists(persistentPath))
            {
                Debug.Log($"[FontManager] Found font at: {persistentPath}");
                // 这里可以实现自定义的字体加载逻辑
            }

            // 方案6: 使用默认字体作为备选
            TMP_FontAsset tmpFontAsset = ScriptableObject.CreateInstance<TMP_FontAsset>();
            tmpFontAsset.name = filename;

            // FntParse fntParse = FntParse.GetFntParse();
            //
            // for (int i = 0; i < fntParse.charInfos.Length; i++)
            // {
            //     // Y 翻转
            //     int flippedY = atlasHeight - (fntY + fntHeight);
            //
            //     // 创建 Metrics 和 Rect
            //     GlyphMetrics metrics = new GlyphMetrics(fntWidth, fntHeight, fntXOffset, fntYOffset + fntHeight, fntXAdvance);
            //     GlyphRect rect = new GlyphRect(fntX, flippedY, fntWidth, fntHeight);
            //     
            //     // 创建 Glyph（最新版 constructor）
            //     Glyph glyph = new Glyph(charId, metrics, rect);
            //
            //     // 添加到表
            //     tmpFontAsset.glyphTable.Add(glyph);
            //     
            //     tmpFontAsset.glyphLookupTable[charId] = glyph;
            //
            //     // 添加字符映射
            //     TMP_Character character = new TMP_Character(charId, glyph);
            //     tmpFontAsset.characterTable.Add(character);
            //     break;
            // }

            // FaceInfo newFaceInfo = new FaceInfo();
            // newFaceInfo.familyName = filename;
            // newFaceInfo.baseline = fntParse.lineBaseHeight;
            // newFaceInfo.lineHeight = fntParse.lineHeight;
            // newFaceInfo.ascentLine = fntParse.lineHeight;
            // newFaceInfo.descentLine = newFaceInfo.ascentLine - fntParse.lineHeight;
            // newFaceInfo.pointSize = fntParse.fontSize;
            // newFaceInfo.capLine = newFaceInfo.ascentLine;
            // newFaceInfo.scale = 1.0f;
            // tmpFontAsset.faceInfo = newFaceInfo;
            
            
            // tmpFontAsset.atlasTextures = new Texture2D[] { fontTexture };
            // Shader bitmapShader = Shader.Find("TextMeshPro/Bitmap");
            // Material fontMaterial = new Material(bitmapShader);
            // fontMaterial.name = fileName + " Material";
            // fontMaterial.mainTexture = fontTexture;
            // tmpFontAsset.material = fontMaterial;

            return tmpFontAsset;
        }

        /// <summary>
        /// 异步加载BMFont字体（用于饥荒字体）
        /// </summary>
        public void LoadBMFont(string fontName, string alias, System.Action<bool> onComplete = null)
        {
            if (string.IsNullOrEmpty(fontName) || string.IsNullOrEmpty(alias))
            {
                Debug.LogWarning("[FontManager] LoadBMFont: fontName or alias is empty");
                onComplete?.Invoke(false);
                return;
            }

            // 如果已加载，直接返回
            if (_loadedFonts.ContainsKey(alias))
            {
                Debug.Log($"[FontManager] BMFont already loaded: {alias}");
                onComplete?.Invoke(true);
                return;
            }

            // StartCoroutine(LoadBMFontCoroutine(fontName, alias, onComplete));
        }

        // private System.Collections.IEnumerator LoadBMFontCoroutine(string fontName, string alias,
        //     System.Action<bool> onComplete)
        // {
        //     bool success = false;
        //
        //     yield return BMFontLoader.LoadBMFontFromStreamingAssets(fontName, (fontAsset) =>
        //     {
        //         if (fontAsset != null)
        //         {
        //             // 创建材质
        //             Material material = new Material(Shader.Find("TextMeshPro/Bitmap"));
        //             material.mainTexture = fontAsset.atlas;
        //             fontAsset.material = material;
        //
        //             // 注册字体
        //             _loadedFonts[alias] = fontAsset;
        //             _fontFilePaths[alias] = fontName;
        //
        //             Debug.Log($"[FontManager] BMFont loaded: {alias} from {fontName}");
        //             success = true;
        //         }
        //         else
        //         {
        //             Debug.LogError($"[FontManager] Failed to load BMFont: {fontName}");
        //         }
        //     });
        //
        //     onComplete?.Invoke(success);
        // }

        /// <summary>
        /// 注册已创建的字体资源
        /// </summary>
        public void RegisterFont(TMP_FontAsset fontAsset, string alias)
        {
            if (fontAsset == null || string.IsNullOrEmpty(alias))
            {
                Debug.LogWarning("[FontManager] RegisterFont: invalid parameters");
                return;
            }

            _loadedFonts[alias] = fontAsset;
            Debug.Log($"[FontManager] Font registered: {alias}");
        }

        /// <summary>
        /// 应用字体到TextMeshProUGUI组件
        /// </summary>
        public void ApplyFontToText(TextMeshProUGUI textComponent, string fontAlias)
        {
            if (textComponent == null || string.IsNullOrEmpty(fontAlias))
                return;

            TMP_FontAsset font = GetFont(fontAlias);
            if (font != null)
            {
                textComponent.font = font;
                
                // 应用字符宽度调整
                float adjustment = GetFontAdvanceAdjustment(fontAlias);
                if (adjustment != 0f)
                {
                    textComponent.characterSpacing = adjustment;
                }
            }
            else
            {
                Debug.LogWarning($"[FontManager] Font '{fontAlias}' not found");
            }
        }

        /// <summary>
        /// 应用字体到TextMeshPro组件（3D）
        /// </summary>
        public void ApplyFontToText(TextMeshPro textComponent, string fontAlias)
        {
            if (textComponent == null || string.IsNullOrEmpty(fontAlias))
                return;

            TMP_FontAsset font = GetFont(fontAlias);
            if (font != null)
            {
                textComponent.font = font;
                
                // 应用字符宽度调整
                float adjustment = GetFontAdvanceAdjustment(fontAlias);
                if (adjustment != 0f)
                {
                    textComponent.characterSpacing = adjustment;
                }
            }
            else
            {
                Debug.LogWarning($"[FontManager] Font '{fontAlias}' not found");
            }
        }

        /// <summary>
        /// 获取所有已加载的字体别名
        /// </summary>
        public string[] GetLoadedFontAliases()
        {
            string[] aliases = new string[_loadedFonts.Count];
            _loadedFonts.Keys.CopyTo(aliases, 0);
            return aliases;
        }

        /// <summary>
        /// 打印所有已加载的字体信息
        /// </summary>
        public void PrintFontInfo()
        {
            Debug.Log("=== Loaded Fonts ===");
            foreach (var kvp in _loadedFonts)
            {
                string fallbackInfo = _fontFallbacks.ContainsKey(kvp.Key) 
                    ? $" (fallbacks: {_fontFallbacks[kvp.Key].Count})"
                    : "";
                string advanceInfo = _fontAdvanceAdjustments.ContainsKey(kvp.Key)
                    ? $" (advance: {_fontAdvanceAdjustments[kvp.Key]})"
                    : "";
                Debug.Log($"  {kvp.Key}: {kvp.Value.name}{fallbackInfo}{advanceInfo}");
            }
        }
    }
}
