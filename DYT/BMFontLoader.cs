// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.IO;
// using System.Xml;
// using UnityEngine;
// using TMPro;
// using UnityEngine.TextCore;
//
// namespace DYT
// {
//     /// <summary>
//     /// BMFont运行时加载器
//     /// 可以在运行时动态加载饥荒的BMFont字体文件
//     /// </summary>
//     public class BMFontLoader : MonoBehaviour
//     {
//         /// <summary>
//         /// 从StreamingAssets加载BMFont字体
//         /// </summary>
//         public static IEnumerator LoadBMFontFromStreamingAssets(string fontName, Action<TMP_FontAsset> onComplete)
//         {
//             string fontPath = Path.Combine(Application.streamingAssetsPath,
//                 $"dont_starve_copy/data/fonts/{fontName}");
//             string fntFile = Path.Combine(fontPath, "font.fnt");
//             string texFile = Path.Combine(fontPath, $"{fontName}_0.png");
//
//             // 如果PNG不存在，尝试其他命名方式
//             if (!File.Exists(texFile))
//             {
//                 texFile = Path.Combine(fontPath, "font_0.png");
//             }
//
//             Debug.Log($"[BMFontLoader] 尝试加载字体: {fontName}");
//             Debug.Log($"[BMFontLoader] FNT路径: {fntFile}");
//             Debug.Log($"[BMFontLoader] 纹理路径: {texFile}");
//
//             if (!File.Exists(fntFile))
//             {
//                 Debug.LogError($"[BMFontLoader] FNT文件不存在: {fntFile}");
//                 onComplete?.Invoke(null);
//                 yield break;
//             }
//
//             // 读取FNT文件
//             string fntContent = File.ReadAllText(fntFile);
//             BMFontData fontData = ParseFNTFile(fntContent);
//
//             if (fontData == null)
//             {
//                 Debug.LogError($"[BMFontLoader] 解析FNT文件失败: {fntFile}");
//                 onComplete?.Invoke(null);
//                 yield break;
//             }
//
//             // 加载纹理
//             Texture2D texture = null;
//             if (File.Exists(texFile))
//             {
//                 byte[] imageData = File.ReadAllBytes(texFile);
//                 texture = new Texture2D(2, 2);
//                 texture.LoadImage(imageData);
//                 texture.filterMode = FilterMode.Bilinear;
//             }
//             else
//             {
//                 Debug.LogWarning($"[BMFontLoader] 纹理文件不存在: {texFile}");
//             }
//
//             // 创建TMP_FontAsset
//             TMP_FontAsset fontAsset = CreateTMPFontAsset(fontData, texture, fontName);
//
//             onComplete?.Invoke(fontAsset);
//             yield return null;
//         }
//
//         private static BMFontData ParseFNTFile(string content)
//         {
//             try
//             {
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
//                 Debug.LogError($"[BMFontLoader] 解析失败: {e.Message}");
//                 return null;
//             }
//         }
//
//         private static BMFontData ParseXMLFormat(string xmlContent)
//         {
//             BMFontData data = new BMFontData();
//             XmlDocument doc = new XmlDocument();
//             doc.LoadXml(xmlContent);
//
//             XmlNode infoNode = doc.SelectSingleNode("//info");
//             if (infoNode != null)
//             {
//                 data.fontSize = int.Parse(infoNode.Attributes["size"]?.Value ?? "32");
//                 data.fontName = infoNode.Attributes["face"]?.Value ?? "BMFont";
//             }
//
//             XmlNode commonNode = doc.SelectSingleNode("//common");
//             if (commonNode != null)
//             {
//                 data.lineHeight = int.Parse(commonNode.Attributes["lineHeight"]?.Value ?? "32");
//                 data.baseline = int.Parse(commonNode.Attributes["base"]?.Value ?? "26");
//                 data.scaleW = int.Parse(commonNode.Attributes["scaleW"]?.Value ?? "512");
//                 data.scaleH = int.Parse(commonNode.Attributes["scaleH"]?.Value ?? "512");
//             }
//
//             XmlNodeList charNodes = doc.SelectNodes("//char");
//             foreach (XmlNode charNode in charNodes)
//             {
//                 BMCharInfo charInfo = new BMCharInfo
//                 {
//                     id = int.Parse(charNode.Attributes["id"].Value),
//                     x = int.Parse(charNode.Attributes["x"].Value),
//                     y = int.Parse(charNode.Attributes["y"].Value),
//                     width = int.Parse(charNode.Attributes["width"].Value),
//                     height = int.Parse(charNode.Attributes["height"].Value),
//                     xoffset = int.Parse(charNode.Attributes["xoffset"].Value),
//                     yoffset = int.Parse(charNode.Attributes["yoffset"].Value),
//                     xadvance = int.Parse(charNode.Attributes["xadvance"].Value)
//                 };
//                 data.chars[charInfo.id] = charInfo;
//             }
//
//             return data;
//         }
//
//         private static BMFontData ParseTextFormat(string textContent)
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
//                     BMCharInfo charInfo = new BMCharInfo
//                     {
//                         id = ParseValue(trimmedLine, "id", 0),
//                         x = ParseValue(trimmedLine, "x", 0),
//                         y = ParseValue(trimmedLine, "y", 0),
//                         width = ParseValue(trimmedLine, "width", 0),
//                         height = ParseValue(trimmedLine, "height", 0),
//                         xoffset = ParseValue(trimmedLine, "xoffset", 0),
//                         yoffset = ParseValue(trimmedLine, "yoffset", 0),
//                         xadvance = ParseValue(trimmedLine, "xadvance", 0)
//                     };
//                     data.chars[charInfo.id] = charInfo;
//                 }
//             }
//
//             return data;
//         }
//
//         private static int ParseValue(string line, string key, int defaultValue)
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
//         private static string ParseStringValue(string line, string key, string defaultValue)
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
//         private static TMP_FontAsset CreateTMPFontAsset(BMFontData fontData, Texture2D texture, string name)
//         {
//             TMP_FontAsset fontAsset = ScriptableObject.CreateInstance<TMP_FontAsset>();
//             fontAsset.name = name;
//
//             if (texture != null)
//             {
//                 fontAsset.atlas = texture;
//             }
//
//             // 设置FaceInfo
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
//                 meanLine = fontData.baseline * 0.7f
//             };
//
//             var faceInfoField = typeof(TMP_FontAsset).GetField("m_FaceInfo",
//                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//             faceInfoField?.SetValue(fontAsset, faceInfo);
//
//             // 创建字符表
//             List<TMP_Character> characters = new List<TMP_Character>();
//             List<UnityEngine.TextCore.Glyph> glyphs = new List<UnityEngine.TextCore.Glyph>();
//
//             foreach (var kvp in fontData.chars)
//             {
//                 BMCharInfo charInfo = kvp.Value;
//                 uint unicode = (uint)charInfo.id;
//
//                 var glyph = new UnityEngine.TextCore.Glyph
//                 {
//                     index = (uint)glyphs.Count,
//                     glyphRect = new UnityEngine.TextCore.GlyphRect(
//                         charInfo.x,
//                         fontData.scaleH - charInfo.y - charInfo.height,
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
//                 TMP_Character character = new TMP_Character(unicode, glyph);
//                 characters.Add(character);
//             }
//
//             var glyphTableField = typeof(TMP_FontAsset).GetField("m_GlyphTable",
//                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//             glyphTableField?.SetValue(fontAsset, glyphs);
//
//             var characterTableField = typeof(TMP_FontAsset).GetField("m_CharacterTable",
//                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//             characterTableField?.SetValue(fontAsset, characters);
//
//             Debug.Log($"[BMFontLoader] 创建字体资源: {name}, 字符数={characters.Count}");
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
