using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

namespace DYT
{
    /// <summary>
    /// 字体管理系统 - 集成Unity的TextMeshPro字体系统
    /// 支持字体加载、卸载、备用字体设置、字符宽度调整等功能
    /// </summary>
    public class FontManager : MonoBehaviour
    {
        private static FontManager _instance;
        public static FontManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<FontManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("FontManager");
                        _instance = go.AddComponent<FontManager>();
                    }
                }
                return _instance;
            }
        }

        // 字体别名 -> TMP_FontAsset 的映射
        private readonly Dictionary<string, TMP_FontAsset> _loadedFonts = 
            new Dictionary<string, TMP_FontAsset>(StringComparer.OrdinalIgnoreCase);

        // 字体别名 -> 备用字体列表 的映射
        private readonly Dictionary<string, List<TMP_FontAsset>> _fontFallbacks = 
            new Dictionary<string, List<TMP_FontAsset>>(StringComparer.OrdinalIgnoreCase);

        // 字体别名 -> 字符宽度调整值 的映射
        private readonly Dictionary<string, float> _fontAdvanceAdjustments = 
            new Dictionary<string, float>(StringComparer.OrdinalIgnoreCase);

        // 字体文件路径缓存
        private readonly Dictionary<string, string> _fontFilePaths = 
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// 加载字体文件并注册别名
        /// </summary>
        public void LoadFont(string filename, string alias)
        {
            if (string.IsNullOrEmpty(filename) || string.IsNullOrEmpty(alias))
            {
                Debug.LogWarning("[FontManager] LoadFont: filename or alias is empty");
                return;
            }

            try
            {
                // 如果已加载，直接返回
                if (_loadedFonts.ContainsKey(alias))
                {
                    Debug.LogWarning(
                        $"FontManager.cs -> LoadFont() -> filename='{filename}', alias='{alias}'\n" +
                        "already loaded"
                    );
                    return;
                }

                // 尝试从Resources加载
                TMP_FontAsset font = LoadFontAsset(filename, alias);
                _loadedFonts[alias] = font;
                _fontFilePaths[alias] = filename;
                Debug.LogWarning(
                    $"FontManager.cs -> LoadFont() -> filename='{filename}', alias='{alias}'");
            }
            catch (Exception e)
            {
                Debug.LogError($"[FontManager] LoadFont('{filename}', '{alias}') error: {e.Message}");
            }
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
                    _fontFilePaths.Remove(alias);
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
            _fontFilePaths.Clear();
            Debug.Log("[FontManager] All fonts unloaded");
        }

        /// <summary>
        /// 加载字体资源的核心方法
        /// </summary>
        private TMP_FontAsset LoadFontAsset(string filename, string alias)
        {
            // 方案1: 从Resources文件夹加载
            TMP_FontAsset font = Resources.Load<TMP_FontAsset>(filename);
            if (font != null)
            {
                return font;
            }

            // 方案2: 从StreamingAssets加载
            string streamingPath = Path.Combine(Application.streamingAssetsPath, filename);
            if (File.Exists(streamingPath))
            {
                // 尝试作为TextAsset加载
                TextAsset textAsset = Resources.Load<TextAsset>(filename);
                if (textAsset != null)
                {
                    Debug.Log($"[FontManager] Loaded font from StreamingAssets: {filename}");
                    return null; // 需要特殊处理
                }
            }

            // 方案3: 从persistentDataPath加载
            string persistentPath = Path.Combine(Application.persistentDataPath, filename);
            if (File.Exists(persistentPath))
            {
                Debug.Log($"[FontManager] Found font at: {persistentPath}");
                // 这里可以实现自定义的字体加载逻辑
            }

            // 方案4: 尝试从项目Assets中查找
            font = Resources.Load<TMP_FontAsset>($"Fonts/{alias}");
            if (font != null)
            {
                return font;
            }

            // 方案5: 使用默认字体作为备选
            font = Resources.Load<TMP_FontAsset>("Fonts/LiberationSans SDF");
            if (font != null)
            {
                Debug.LogWarning($"[FontManager] Font '{filename}' not found, using default font");
                return font;
            }

            return null;
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
