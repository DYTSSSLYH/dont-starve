// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Xml;
// using UnityEngine;
// using UnityEditor;
// using TMPro;
// using UnityEngine.TextCore;
// using UnityEngine.TextCore.LowLevel;
//
// namespace DYT.Editor
// {
//     /// <summary>
//     /// BMFont格式转换为TextMeshPro字体资源的工具
//     /// 用于将饥荒游戏中的.fnt字体文件转换为Unity TMP可用的格式
//     /// </summary>
//     public class BMFontToTMPConverter : EditorWindow
//     {
//         private string fntFilePath = "";
//         private Texture2D fontTexture;
//         private string outputPath = "Assets/Fonts/";
//         private string fontName = "ConvertedFont";
//         private Vector2 scrollPos;
//
//         [MenuItem("Tools/DYT/BMFont to TMP Converter")]
//         public static void ShowWindow()
//         {
//             var window = GetWindow<BMFontToTMPConverter>("BMFont转TMP工具");
//             window.minSize = new Vector2(500, 400);
//         }
//
//         private void OnGUI()
//         {
//             scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
//
//             EditorGUILayout.Space(10);
//             EditorGUILayout.LabelField("饥荒BMFont字体转换为TMP字体", EditorStyles.boldLabel);
//             EditorGUILayout.HelpBox(
//                 "此工具用于将饥荒游戏中的BMFont格式字体(.fnt + 纹理)转换为Unity TextMeshPro可用的字体资源。\n\n" +
//                 "步骤：\n" +
//                 "1. 选择.fnt字体描述文件\n" +
//                 "2. 选择对应的字体纹理图片\n" +
//                 "3. 设置输出路径和字体名称\n" +
//                 "4. 点击转换按钮",
//                 MessageType.Info
//             );
//
//             EditorGUILayout.Space(10);
//
//             // FNT文件路径
//             EditorGUILayout.LabelField("1. 选择.fnt字体文件", EditorStyles.boldLabel);
//             EditorGUILayout.BeginHorizontal();
//             fntFilePath = EditorGUILayout.TextField("FNT文件路径:", fntFilePath);
//             if (GUILayout.Button("浏览...", GUILayout.Width(80)))
//             {
//                 string path = EditorUtility.OpenFilePanel("选择FNT文件", Application.dataPath, "fnt");
//                 if (!string.IsNullOrEmpty(path))
//                 {
//                     fntFilePath = path;
//                 }
//             }
//             EditorGUILayout.EndHorizontal();
//
//             // 字体纹理
//             EditorGUILayout.Space(5);
//             EditorGUILayout.LabelField("2. 选择字体纹理", EditorStyles.boldLabel);
//             fontTexture = (Texture2D)EditorGUILayout.ObjectField("字体纹理:", fontTexture, typeof(Texture2D), false);
//
//             // 输出设置
//             EditorGUILayout.Space(10);
//             EditorGUILayout.LabelField("3. 输出设置", EditorStyles.boldLabel);
//             fontName = EditorGUILayout.TextField("字体名称:", fontName);
//
//             EditorGUILayout.BeginHorizontal();
//             outputPath = EditorGUILayout.TextField("输出路径:", outputPath);
//             if (GUILayout.Button("浏览...", GUILayout.Width(80)))
//             {
//                 string path = EditorUtility.SaveFolderPanel("选择输出文件夹", "Assets", "");
//                 if (!string.IsNullOrEmpty(path))
//                 {
//                     if (path.StartsWith(Application.dataPath))
//                     {
//                         outputPath = "Assets" + path.Substring(Application.dataPath.Length);
//                     }
//                 }
//             }
//             EditorGUILayout.EndHorizontal();
//
//             EditorGUILayout.Space(10);
//
//             // 转换按钮
//             GUI.enabled = !string.IsNullOrEmpty(fntFilePath) && fontTexture != null && !string.IsNullOrEmpty(fontName);
//             if (GUILayout.Button("开始转换", GUILayout.Height(40)))
//             {
//                 ConvertBMFontToTMP();
//             }
//             GUI.enabled = true;
//
//             EditorGUILayout.Space(10);
//
//             // 快速转换区域
//             EditorGUILayout.LabelField("快速转换（饥荒字体）", EditorStyles.boldLabel);
//             if (GUILayout.Button("转换: opensans50"))
//             {
//                 QuickConvert("opensans50");
//             }
//             if (GUILayout.Button("转换: belisaplumilla50"))
//             {
//                 QuickConvert("belisaplumilla50");
//             }
//             if (GUILayout.Button("转换: buttonfont"))
//             {
//                 QuickConvert("buttonfont");
//             }
//
//             EditorGUILayout.EndScrollView();
//         }
//
//         private void QuickConvert(string fontFolderName)
//         {
//             string basePath = "Assets/StreamingAssets/dont_starve_copy/data/fonts/" + fontFolderName;
//             string fntPath = Path.Combine(Application.dataPath.Replace("Assets", basePath), "font.fnt");
//
//             // 尝试查找对应的PNG纹理
//             string texPath = Path.Combine(Application.dataPath.Replace("Assets", basePath), fontFolderName + "_0.png");
//             if (!File.Exists(texPath))
//             {
//                 texPath = Path.Combine(Application.dataPath.Replace("Assets", basePath), "font_0.png");
//             }
//
//             if (File.Exists(fntPath))
//             {
//                 fntFilePath = fntPath;
//
//                 // 尝试加载纹理
//                 string relativeTexPath = texPath.Replace(Application.dataPath, "Assets");
//                 fontTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(relativeTexPath);
//
//                 fontName = fontFolderName + "_SDF";
//                 outputPath = "Assets/Fonts/";
//
//                 if (fontTexture != null)
//                 {
//                     ConvertBMFontToTMP();
//                 }
//                 else
//                 {
//                     Debug.LogWarning($"未找到纹理文件，请手动选择纹理: {texPath}");
//                 }
//             }
//             else
//             {
//                 Debug.LogError($"未找到字体文件: {fntPath}");
//             }
//         }
//
//         private void ConvertBMFontToTMP()
//         {
//             try
//             {
//                 // 检查纹理
//                 if (fontTexture == null)
//                 {
//                     EditorUtility.DisplayDialog("错误", "字体纹理为空！请先选择纹理图片。", "确定");
//                     return;
//                 }
//
//                 // 确保纹理导入设置正确
//                 string texturePath = AssetDatabase.GetAssetPath(fontTexture);
//                 if (!string.IsNullOrEmpty(texturePath))
//                 {
//                     TextureImporter textureImporter = AssetImporter.GetAtPath(texturePath) as TextureImporter;
//                     if (textureImporter != null)
//                     {
//                         bool needReimport = false;
//                         
//                         // 设置为可读，确保纹理数据可用
//                         if (!textureImporter.isReadable)
//                         {
//                             textureImporter.isReadable = true;
//                             needReimport = true;
//                         }
//                         
//                         // 确保纹理类型正确（对于字体纹理，使用Default即可）
//                         if (textureImporter.textureType != TextureImporterType.Default)
//                         {
//                             textureImporter.textureType = TextureImporterType.Default;
//                             needReimport = true;
//                         }
//                         
//                         // 确保不生成mipmap（字体纹理不需要）
//                         if (textureImporter.mipmapEnabled)
//                         {
//                             textureImporter.mipmapEnabled = false;
//                             needReimport = true;
//                         }
//                         
//                         if (needReimport)
//                         {
//                             textureImporter.SaveAndReimport();
//                             Debug.Log($"[BMFontConverter] 已更新纹理导入设置: {texturePath}");
//                         }
//                     }
//                 }
//                 else
//                 {
//                     Debug.LogWarning($"[BMFontConverter] 无法获取纹理路径，纹理可能未正确导入到Unity项目中！");
//                 }
//
//                 // 解析FNT文件
//                 BMFontData fontData = ParseFNTFile(fntFilePath);
//                 if (fontData == null)
//                 {
//                     EditorUtility.DisplayDialog("错误", "解析FNT文件失败！", "确定");
//                     return;
//                 }
//
//                 // 创建材质（在创建字体资源之前）
//                 Shader bitmapShader = Shader.Find("TextMeshPro/Bitmap");
//                 if (bitmapShader == null)
//                 {
//                     // 尝试其他可能的shader名称
//                     bitmapShader = Shader.Find("TMPro/Bitmap");
//                     if (bitmapShader == null)
//                     {
//                         EditorUtility.DisplayDialog("错误", 
//                             "找不到TextMeshPro/Bitmap shader！\n请确保TextMeshPro已正确导入。", "确定");
//                         return;
//                     }
//                 }
//
//                 Material material = new Material(bitmapShader);
//                 material.name = fontName + "_Material";
//                 material.mainTexture = fontTexture;
//
//                 // 创建TMP_FontAsset
//                 TMP_FontAsset fontAsset = CreateTMPFontAsset(fontData, fontTexture, fontName);
//                 
//                 // 设置材质（必须在创建asset之前设置）
//                 fontAsset.material = material;
//
//                 // 保存资源
//                 if (!Directory.Exists(outputPath))
//                 {
//                     Directory.CreateDirectory(outputPath);
//                 }
//
//                 string assetPath = Path.Combine(outputPath, fontName + ".asset");
//                 string materialPath = Path.Combine(outputPath, fontName + "_Material.mat");
//                 
//                 // 保存之前，备份数据
//                 var glyphTableField = typeof(TMP_FontAsset).GetField("m_GlyphTable",
//                     System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//                 var characterTableField = typeof(TMP_FontAsset).GetField("m_CharacterTable",
//                     System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//                 
//                 List<UnityEngine.TextCore.Glyph> backupGlyphs = null;
//                 List<TMP_Character> backupCharacters = null;
//                 
//                 if (glyphTableField != null && characterTableField != null)
//                 {
//                     backupGlyphs = glyphTableField.GetValue(fontAsset) as List<UnityEngine.TextCore.Glyph>;
//                     backupCharacters = characterTableField.GetValue(fontAsset) as List<TMP_Character>;
//                     
//                     // 创建新的列表副本，确保数据独立
//                     if (backupGlyphs != null)
//                     {
//                         backupGlyphs = new List<UnityEngine.TextCore.Glyph>(backupGlyphs);
//                     }
//                     if (backupCharacters != null)
//                     {
//                         backupCharacters = new List<TMP_Character>(backupCharacters);
//                     }
//                     
//                     Debug.Log($"[BMFontConverter] 备份数据：{backupGlyphs?.Count ?? 0} 个字形，{backupCharacters?.Count ?? 0} 个字符");
//                 }
//
//                 // 标记为已修改（在CreateAsset之前）
//                 EditorUtility.SetDirty(fontAsset);
//                 
//                 // 先保存材质
//                 AssetDatabase.CreateAsset(material, materialPath);
//                 
//                 // 再保存字体资源
//                 AssetDatabase.CreateAsset(fontAsset, assetPath);
//                 
//                 // 立即保存并刷新
//                 AssetDatabase.SaveAssets();
//                 AssetDatabase.Refresh();
//                 
//                 // 等待Unity完成字体升级（Unity会在保存后自动升级字体资源）
//                 // 然后重新加载并检查
//                 System.Threading.Thread.Sleep(100); // 给Unity一点时间完成升级
//                 AssetDatabase.Refresh();
//                 
//                 // 重新加载字体资源
//                 var savedFontAsset = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(assetPath);
//                 if (savedFontAsset != null && backupGlyphs != null && backupCharacters != null && 
//                     backupGlyphs.Count > 0 && backupCharacters.Count > 0)
//                 {
//                     // 检查保存后的数据
//                     var savedGlyphTableField = typeof(TMP_FontAsset).GetField("m_GlyphTable",
//                         System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//                     var savedCharacterTableField = typeof(TMP_FontAsset).GetField("m_CharacterTable",
//                         System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//                     
//                     if (savedGlyphTableField != null && savedCharacterTableField != null)
//                     {
//                         var savedGlyphs = savedGlyphTableField.GetValue(savedFontAsset) as List<UnityEngine.TextCore.Glyph>;
//                         var savedCharacters = savedCharacterTableField.GetValue(savedFontAsset) as List<TMP_Character>;
//                         
//                         // 如果数据丢失或字符数减少（Unity升级可能只保留空格），重新设置
//                         if (savedGlyphs == null || savedGlyphs.Count < backupGlyphs.Count || 
//                             savedCharacters == null || savedCharacters.Count < backupCharacters.Count)
//                         {
//                             int lostCount = (backupCharacters?.Count ?? 0) - (savedCharacters?.Count ?? 0);
//                             Debug.LogWarning($"[BMFontConverter] 检测到字符丢失（可能由Unity字体升级导致）！丢失了 {lostCount} 个字符，重新设置：{backupGlyphs.Count} 个字形，{backupCharacters.Count} 个字符");
//                             
//                             // 重新设置数据
//                             savedGlyphTableField.SetValue(savedFontAsset, backupGlyphs);
//                             savedCharacterTableField.SetValue(savedFontAsset, backupCharacters);
//                             
//                             // 重要：确保atlas纹理正确关联
//                             if (fontTexture != null)
//                             {
//                                 savedFontAsset.atlas = fontTexture;
//                                 Debug.Log($"[BMFontConverter] 已重新设置atlas纹理: {fontTexture.name}");
//                             }
//                             
//                             // 重要：确保材质正确关联并设置纹理
//                             if (material != null)
//                             {
//                                 savedFontAsset.material = material;
//                                 if (material.mainTexture != fontTexture)
//                                 {
//                                     material.mainTexture = fontTexture;
//                                     EditorUtility.SetDirty(material);
//                                     Debug.Log($"[BMFontConverter] 已更新材质的纹理");
//                                 }
//                             }
//                             
//                             // 重新设置查找表
//                             var characterLookupTableField = typeof(TMP_FontAsset).GetField("m_CharacterLookupTable",
//                                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//                             if (characterLookupTableField != null)
//                             {
//                                 Dictionary<uint, TMP_Character> lookupTable = new Dictionary<uint, TMP_Character>();
//                                 foreach (var character in backupCharacters)
//                                 {
//                                     lookupTable[character.unicode] = character;
//                                 }
//                                 characterLookupTableField.SetValue(savedFontAsset, lookupTable);
//                             }
//                             
//                             // 重新设置glyph查找表
//                             var glyphLookupTableField = typeof(TMP_FontAsset).GetField("m_GlyphLookupTable",
//                                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//                             if (glyphLookupTableField != null)
//                             {
//                                 Dictionary<uint, UnityEngine.TextCore.Glyph> glyphLookup = new Dictionary<uint, UnityEngine.TextCore.Glyph>();
//                                 for (int i = 0; i < backupGlyphs.Count; i++)
//                                 {
//                                     glyphLookup[(uint)i] = backupGlyphs[i];
//                                 }
//                                 glyphLookupTableField.SetValue(savedFontAsset, glyphLookup);
//                             }
//                             
//                             // 标记为已修改并保存
//                             EditorUtility.SetDirty(savedFontAsset);
//                             AssetDatabase.SaveAssets();
//                             AssetDatabase.Refresh();
//                             
//                             Debug.Log($"[BMFontConverter] 已重新设置并保存：{backupCharacters.Count} 个字符");
//                             
//                             // 再次验证（等待一下让Unity处理）
//                             System.Threading.Thread.Sleep(50);
//                             AssetDatabase.Refresh();
//                             
//                             var verifyGlyphs = savedGlyphTableField.GetValue(savedFontAsset) as List<UnityEngine.TextCore.Glyph>;
//                             var verifyCharacters = savedCharacterTableField.GetValue(savedFontAsset) as List<TMP_Character>;
//                             Debug.Log($"[BMFontConverter] 最终验证：{verifyGlyphs?.Count ?? 0} 个字形，{verifyCharacters?.Count ?? 0} 个字符");
//                             
//                             // 如果还是丢失，再试一次
//                             if (verifyCharacters == null || verifyCharacters.Count < backupCharacters.Count)
//                             {
//                                 Debug.LogWarning($"[BMFontConverter] 字符仍然丢失，进行第二次恢复...");
//                                 savedGlyphTableField.SetValue(savedFontAsset, backupGlyphs);
//                                 savedCharacterTableField.SetValue(savedFontAsset, backupCharacters);
//                                 
//                                 // 再次确保atlas和material正确
//                                 if (fontTexture != null)
//                                 {
//                                     savedFontAsset.atlas = fontTexture;
//                                 }
//                                 if (material != null)
//                                 {
//                                     savedFontAsset.material = material;
//                                 }
//                                 
//                                 EditorUtility.SetDirty(savedFontAsset);
//                                 AssetDatabase.SaveAssets();
//                                 AssetDatabase.Refresh();
//                             }
//                         }
//                         else
//                         {
//                             Debug.Log($"[BMFontConverter] 保存后验证：字体包含 {savedCharacters.Count} 个字符");
//                             
//                             // 即使字符数正确，也要确保atlas和material正确设置
//                             if (fontTexture != null && savedFontAsset.atlas != fontTexture)
//                             {
//                                 savedFontAsset.atlas = fontTexture;
//                                 Debug.Log($"[BMFontConverter] 已重新设置atlas纹理");
//                             }
//                             
//                             if (material != null && savedFontAsset.material != material)
//                             {
//                                 savedFontAsset.material = material;
//                                 if (material.mainTexture != fontTexture)
//                                 {
//                                     material.mainTexture = fontTexture;
//                                     EditorUtility.SetDirty(material);
//                                 }
//                                 Debug.Log($"[BMFontConverter] 已重新设置材质");
//                             }
//                             
//                             EditorUtility.SetDirty(savedFontAsset);
//                             AssetDatabase.SaveAssets();
//                         }
//                     }
//                 }
//                 
//                 // 最终验证：确保atlas和material都正确设置
//                 var finalFontAsset = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(assetPath);
//                 if (finalFontAsset != null)
//                 {
//                     if (finalFontAsset.atlas == null && fontTexture != null)
//                     {
//                         Debug.LogWarning("[BMFontConverter] 最终检查：atlas为空，正在修复...");
//                         finalFontAsset.atlas = fontTexture;
//                         EditorUtility.SetDirty(finalFontAsset);
//                         AssetDatabase.SaveAssets();
//                     }
//                     
//                     if (finalFontAsset.material == null && material != null)
//                     {
//                         Debug.LogWarning("[BMFontConverter] 最终检查：material为空，正在修复...");
//                         finalFontAsset.material = material;
//                         EditorUtility.SetDirty(finalFontAsset);
//                         AssetDatabase.SaveAssets();
//                     }
//                     
//                     Debug.Log($"[BMFontConverter] 最终检查完成：Atlas={(finalFontAsset.atlas != null ? finalFontAsset.atlas.name : "null")}, Material={(finalFontAsset.material != null ? finalFontAsset.material.name : "null")}");
//                 }
//
//                 EditorUtility.DisplayDialog("成功",
//                     $"字体转换成功！\n保存位置: {assetPath}", "确定");
//
//                 Selection.activeObject = fontAsset;
//                 EditorGUIUtility.PingObject(fontAsset);
//
//                 Debug.Log($"[BMFontConverter] 字体转换成功: {fontName}");
//             }
//             catch (Exception e)
//             {
//                 EditorUtility.DisplayDialog("错误",
//                     $"转换失败: {e.Message}\n\n{e.StackTrace}", "确定");
//                 Debug.LogError($"[BMFontConverter] 转换失败: {e.Message}\n{e.StackTrace}");
//             }
//         }
//
//         private BMFontData ParseFNTFile(string filePath)
//         {
//             try
//             {
//                 string content = File.ReadAllText(filePath);
//
//                 // 尝试XML格式解析
//                 if (content.TrimStart().StartsWith("<?xml") || content.TrimStart().StartsWith("<font"))
//                 {
//                     return ParseXMLFormat(content);
//                 }
//                 else
//                 {
//                     return ParseTextFormat(content);
//                 }
//             }
//             catch (Exception e)
//             {
//                 Debug.LogError($"解析FNT文件失败: {e.Message}");
//                 return null;
//             }
//         }
//
//         private BMFontData ParseXMLFormat(string xmlContent)
//         {
//             BMFontData data = new BMFontData();
//             XmlDocument doc = new XmlDocument();
//             doc.LoadXml(xmlContent);
//
//             // 解析info
//             XmlNode infoNode = doc.SelectSingleNode("//info");
//             if (infoNode != null)
//             {
//                 data.fontSize = int.Parse(infoNode.Attributes["size"]?.Value ?? "32");
//                 data.fontName = infoNode.Attributes["face"]?.Value ?? "BMFont";
//             }
//
//             // 解析common
//             XmlNode commonNode = doc.SelectSingleNode("//common");
//             if (commonNode != null)
//             {
//                 data.lineHeight = int.Parse(commonNode.Attributes["lineHeight"]?.Value ?? "32");
//                 data.baseline = int.Parse(commonNode.Attributes["base"]?.Value ?? "26");
//                 data.scaleW = int.Parse(commonNode.Attributes["scaleW"]?.Value ?? "512");
//                 data.scaleH = int.Parse(commonNode.Attributes["scaleH"]?.Value ?? "512");
//             }
//
//             // 解析字符
//             XmlNodeList charNodes = doc.SelectNodes("//char");
//             foreach (XmlNode charNode in charNodes)
//             {
//                 BMCharInfo charInfo = new BMCharInfo();
//                 charInfo.id = int.Parse(charNode.Attributes["id"].Value);
//                 charInfo.x = int.Parse(charNode.Attributes["x"].Value);
//                 charInfo.y = int.Parse(charNode.Attributes["y"].Value);
//                 charInfo.width = int.Parse(charNode.Attributes["width"].Value);
//                 charInfo.height = int.Parse(charNode.Attributes["height"].Value);
//                 charInfo.xoffset = int.Parse(charNode.Attributes["xoffset"].Value);
//                 charInfo.yoffset = int.Parse(charNode.Attributes["yoffset"].Value);
//                 charInfo.xadvance = int.Parse(charNode.Attributes["xadvance"].Value);
//
//                 data.chars[charInfo.id] = charInfo;
//             }
//
//             Debug.Log($"解析XML格式FNT: 字符数={data.chars.Count}");
//             return data;
//         }
//
//         private BMFontData ParseTextFormat(string textContent)
//         {
//             BMFontData data = new BMFontData();
//             string[] lines = textContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
//
//             foreach (string line in lines)
//             {
//                 string trimmedLine = line.Trim();
//
//                 if (trimmedLine.StartsWith("info"))
//                 {
//                     data.fontSize = ParseValue(trimmedLine, "size", 32);
//                     data.fontName = ParseStringValue(trimmedLine, "face", "BMFont");
//                 }
//                 else if (trimmedLine.StartsWith("common"))
//                 {
//                     data.lineHeight = ParseValue(trimmedLine, "lineHeight", 32);
//                     data.baseline = ParseValue(trimmedLine, "base", 26);
//                     data.scaleW = ParseValue(trimmedLine, "scaleW", 512);
//                     data.scaleH = ParseValue(trimmedLine, "scaleH", 512);
//                 }
//                 else if (trimmedLine.StartsWith("char "))
//                 {
//                     BMCharInfo charInfo = new BMCharInfo();
//                     charInfo.id = ParseValue(trimmedLine, "id", 0);
//                     charInfo.x = ParseValue(trimmedLine, "x", 0);
//                     charInfo.y = ParseValue(trimmedLine, "y", 0);
//                     charInfo.width = ParseValue(trimmedLine, "width", 0);
//                     charInfo.height = ParseValue(trimmedLine, "height", 0);
//                     charInfo.xoffset = ParseValue(trimmedLine, "xoffset", 0);
//                     charInfo.yoffset = ParseValue(trimmedLine, "yoffset", 0);
//                     charInfo.xadvance = ParseValue(trimmedLine, "xadvance", 0);
//
//                     data.chars[charInfo.id] = charInfo;
//                 }
//             }
//
//             Debug.Log($"解析文本格式FNT: 字符数={data.chars.Count}");
//             return data;
//         }
//
//         private int ParseValue(string line, string key, int defaultValue)
//         {
//             string pattern = key + "=";
//             int startIndex = line.IndexOf(pattern);
//             if (startIndex < 0) return defaultValue;
//
//             startIndex += pattern.Length;
//             int endIndex = line.IndexOf(' ', startIndex);
//             if (endIndex < 0) endIndex = line.Length;
//
//             string value = line.Substring(startIndex, endIndex - startIndex);
//             return int.TryParse(value, out int result) ? result : defaultValue;
//         }
//
//         private string ParseStringValue(string line, string key, string defaultValue)
//         {
//             string pattern = key + "=\"";
//             int startIndex = line.IndexOf(pattern);
//             if (startIndex < 0) return defaultValue;
//
//             startIndex += pattern.Length;
//             int endIndex = line.IndexOf('\"', startIndex);
//             if (endIndex < 0) return defaultValue;
//
//             return line.Substring(startIndex, endIndex - startIndex);
//         }
//
//         private TMP_FontAsset CreateTMPFontAsset(BMFontData fontData, Texture2D texture, string name)
//         {
//             TMP_FontAsset fontAsset = ScriptableObject.CreateInstance<TMP_FontAsset>();
//             fontAsset.name = name;
//
//             // 设置基本信息
//             fontAsset.atlas = texture;
//             
//             // 设置atlas纹理模式为位图（如果字段存在）
//             // 注意：不同版本的TextMeshPro可能使用不同的枚举类型
//             var atlasTextureModeField = typeof(TMP_FontAsset).GetField("m_AtlasTextureMode",
//                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//             if (atlasTextureModeField != null)
//             {
//                 var fieldType = atlasTextureModeField.FieldType;
//                 // 尝试使用整数值 0 表示位图模式（通常位图=0, SDF=其他值）
//                 if (fieldType.IsEnum)
//                 {
//                     // 如果是枚举，尝试获取第一个值（通常是位图模式）
//                     var enumValues = System.Enum.GetValues(fieldType);
//                     if (enumValues.Length > 0)
//                     {
//                         atlasTextureModeField.SetValue(fontAsset, enumValues.GetValue(0));
//                     }
//                 }
//                 else if (fieldType == typeof(int))
//                 {
//                     // 如果是整数，使用 0 表示位图模式
//                     atlasTextureModeField.SetValue(fontAsset, 0);
//                 }
//             }
//
//             // 使用反射或直接访问m_FaceInfo字段设置FaceInfo
//             var faceInfo = new UnityEngine.TextCore.FaceInfo
//             {
//                 familyName = fontData.fontName,
//                 styleName = "Regular",
//                 pointSize = fontData.fontSize,
//                 scale = 1.0f,
//                 lineHeight = fontData.lineHeight,
//                 ascentLine = fontData.baseline,
//                 baseline = 0,
//                 descentLine = -(fontData.lineHeight - fontData.baseline),
//                 capLine = fontData.baseline,
//                 meanLine = fontData.baseline * 0.7f,
//                 superscriptOffset = fontData.baseline * 0.5f,
//                 subscriptOffset = -fontData.baseline * 0.3f,
//                 underlineOffset = -fontData.baseline * 0.1f,
//                 underlineThickness = fontData.fontSize * 0.05f,
//                 strikethroughOffset = fontData.baseline * 0.5f,
//                 strikethroughThickness = fontData.fontSize * 0.05f,
//                 tabWidth = fontData.fontSize * 4
//             };
//
//             // 使用反射设置只读属性
//             var faceInfoField = typeof(TMP_FontAsset).GetField("m_FaceInfo",
//                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//             if (faceInfoField != null)
//             {
//                 faceInfoField.SetValue(fontAsset, faceInfo);
//             }
//
//             // 创建字形表和字符表
//             List<TMP_Character> characters = new List<TMP_Character>();
//             List<UnityEngine.TextCore.Glyph> glyphs = new List<UnityEngine.TextCore.Glyph>();
//
//             Debug.Log($"[BMFontConverter] 开始创建字符表，共 {fontData.chars.Count} 个字符");
//
//             foreach (var kvp in fontData.chars)
//             {
//                 BMCharInfo charInfo = kvp.Value;
//                 uint unicode = (uint)charInfo.id;
//
//                 // 创建Glyph
//                 uint glyphIndex = (uint)glyphs.Count;
//                 UnityEngine.TextCore.Glyph glyph = new UnityEngine.TextCore.Glyph
//                 {
//                     index = glyphIndex,
//                     glyphRect = new UnityEngine.TextCore.GlyphRect(
//                         charInfo.x,
//                         fontData.scaleH - charInfo.y - charInfo.height, // Y轴翻转
//                         charInfo.width,
//                         charInfo.height
//                     ),
//                     metrics = new UnityEngine.TextCore.GlyphMetrics(
//                         charInfo.width,
//                         charInfo.height,
//                         charInfo.xoffset,
//                         fontData.baseline - charInfo.yoffset - charInfo.height,
//                         charInfo.xadvance
//                     ),
//                     scale = 1.0f
//                 };
//                 glyphs.Add(glyph);
//
//                 // 创建Character - 确保正确引用glyph
//                 TMP_Character character = new TMP_Character(unicode, glyph);
//                 characters.Add(character);
//             }
//
//             Debug.Log($"[BMFontConverter] 创建了 {glyphs.Count} 个字形和 {characters.Count} 个字符");
//
//             // 重要：先设置glyphTable，再设置characterTable（因为character引用了glyph）
//             var glyphTableField = typeof(TMP_FontAsset).GetField("m_GlyphTable",
//                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//             if (glyphTableField != null)
//             {
//                 glyphTableField.SetValue(fontAsset, glyphs);
//                 Debug.Log($"[BMFontConverter] 已设置GlyphTable，包含 {glyphs.Count} 个字形");
//             }
//             else
//             {
//                 Debug.LogError("[BMFontConverter] 无法找到m_GlyphTable字段！");
//             }
//
//             // 确保字符表中的每个字符都正确引用了glyph
//             // 重新创建字符列表以确保引用正确
//             List<TMP_Character> verifiedCharacters = new List<TMP_Character>();
//             for (int i = 0; i < characters.Count; i++)
//             {
//                 var originalChar = characters[i];
//                 // 确保glyph引用正确
//                 if (i < glyphs.Count)
//                 {
//                     var glyph = glyphs[i];
//                     TMP_Character verifiedChar = new TMP_Character(originalChar.unicode, glyph);
//                     verifiedCharacters.Add(verifiedChar);
//                 }
//                 else
//                 {
//                     Debug.LogWarning($"[BMFontConverter] 字符 {originalChar.unicode} 的glyph索引超出范围！");
//                     verifiedCharacters.Add(originalChar);
//                 }
//             }
//
//             var characterTableField = typeof(TMP_FontAsset).GetField("m_CharacterTable",
//                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//             if (characterTableField != null)
//             {
//                 characterTableField.SetValue(fontAsset, verifiedCharacters);
//                 Debug.Log($"[BMFontConverter] 已设置CharacterTable，包含 {verifiedCharacters.Count} 个字符");
//                 
//                 // 更新characters引用以便后续使用
//                 characters = verifiedCharacters;
//             }
//             else
//             {
//                 Debug.LogError("[BMFontConverter] 无法找到m_CharacterTable字段！");
//             }
//
//             // 手动构建字符查找表 - 这是关键！
//             var characterLookupTableField = typeof(TMP_FontAsset).GetField("m_CharacterLookupTable",
//                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//             if (characterLookupTableField != null)
//             {
//                 Dictionary<uint, TMP_Character> lookupTable = new Dictionary<uint, TMP_Character>();
//                 foreach (var character in characters)
//                 {
//                     lookupTable[character.unicode] = character;
//                 }
//                 characterLookupTableField.SetValue(fontAsset, lookupTable);
//                 Debug.Log($"[BMFontConverter] 已设置CharacterLookupTable，包含 {lookupTable.Count} 个字符映射");
//             }
//             else
//             {
//                 Debug.LogWarning("[BMFontConverter] 无法找到m_CharacterLookupTable字段！");
//             }
//
//             // 尝试设置glyph查找表
//             var glyphLookupTableField = typeof(TMP_FontAsset).GetField("m_GlyphLookupTable",
//                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//             if (glyphLookupTableField != null)
//             {
//                 Dictionary<uint, UnityEngine.TextCore.Glyph> glyphLookup = new Dictionary<uint, UnityEngine.TextCore.Glyph>();
//                 for (int i = 0; i < glyphs.Count; i++)
//                 {
//                     glyphLookup[(uint)i] = glyphs[i];
//                 }
//                 glyphLookupTableField.SetValue(fontAsset, glyphLookup);
//                 Debug.Log($"[BMFontConverter] 已设置GlyphLookupTable");
//             }
//
//             // 尝试设置glyphIndexLookupTable
//             var glyphIndexLookupTableField = typeof(TMP_FontAsset).GetField("m_GlyphIndexLookupTable",
//                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//             if (glyphIndexLookupTableField != null)
//             {
//                 Dictionary<uint, uint> glyphIndexLookup = new Dictionary<uint, uint>();
//                 for (int i = 0; i < glyphs.Count; i++)
//                 {
//                     glyphIndexLookup[(uint)i] = (uint)i;
//                 }
//                 glyphIndexLookupTableField.SetValue(fontAsset, glyphIndexLookup);
//                 Debug.Log($"[BMFontConverter] 已设置GlyphIndexLookupTable");
//             }
//
//             // 重要：在返回之前，确保所有数据都已正确设置
//             // 不要在这里调用可能清空数据的方法
//             // 某些TMP方法可能会重新初始化数据，导致我们设置的数据丢失
//             
//             // 只调用安全的初始化方法
//             try
//             {
//                 var initMethod = typeof(TMP_FontAsset).GetMethod("InitializeDictionaryLookupTables",
//                     System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
//                 if (initMethod != null)
//                 {
//                     try
//                     {
//                         initMethod.Invoke(fontAsset, null);
//                         Debug.Log($"[BMFontConverter] 成功调用方法: InitializeDictionaryLookupTables");
//                     }
//                     catch (Exception ex)
//                     {
//                         Debug.LogWarning($"[BMFontConverter] 调用InitializeDictionaryLookupTables时出错: {ex.Message}");
//                     }
//                 }
//             }
//             catch (Exception e)
//             {
//                 Debug.LogWarning($"[BMFontConverter] 无法调用InitializeDictionaryLookupTables: {e.Message}");
//             }
//             
//             // 注意：不要调用ReadFontAssetDefinition或UpdateFontAssetData
//             // 这些方法可能会重新初始化数据，导致我们设置的数据丢失
//
//             // 验证字符表
//             var verifyCharacterTable = characterTableField?.GetValue(fontAsset) as List<TMP_Character>;
//             if (verifyCharacterTable != null)
//             {
//                 Debug.Log($"[BMFontConverter] 验证：CharacterTable包含 {verifyCharacterTable.Count} 个字符");
//                 if (verifyCharacterTable.Count > 0)
//                 {
//                     var firstChar = verifyCharacterTable[0];
//                     Debug.Log($"[BMFontConverter] 第一个字符: Unicode={firstChar.unicode}, GlyphIndex={firstChar.glyph.index}");
//                 }
//             }
//
//             Debug.Log($"[BMFontConverter] 创建TMP_FontAsset完成: {name}, 字符数={characters.Count}, 字形数={glyphs.Count}");
//             return fontAsset;
//         }
//
//         // 数据结构
//         private class BMFontData
//         {
//             public string fontName = "BMFont";
//             public int fontSize = 32;
//             public int lineHeight = 32;
//             public int baseline = 26;
//             public int scaleW = 512;
//             public int scaleH = 512;
//             public Dictionary<int, BMCharInfo> chars = new Dictionary<int, BMCharInfo>();
//         }
//
//         private class BMCharInfo
//         {
//             public int id;
//             public int x, y;
//             public int width, height;
//             public int xoffset, yoffset;
//             public int xadvance;
//         }
//     }
// }
