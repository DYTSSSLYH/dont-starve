using System.Collections.Generic;
using System.IO;

namespace DYT.Tools
{
    public static class IniTool
    {
        private static readonly Dictionary<string, Dictionary<string, string>> _cache = new();
        
        public static void LoadConfigFile(string path)
        {
            string key = "";
            
            foreach (string line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                
                
                if (line.StartsWith('[') && line.EndsWith(']'))
                {
                    key = line.Substring(1, line.Length - 2);
                    _cache.Add(key, new Dictionary<string, string>());
                    continue;
                }

                string[] split = line.Split('=');
                _cache[key].Add(split[0].Trim(),
                    split[1].Trim().Replace("\"", "").Replace("\\n", "\n").Replace("\\t", "\t"));
            }
        }
        
        public static string GetContent(string mainKey, string subKey)
        {
            if (!_cache.ContainsKey(mainKey)) return null;
            if (!_cache[mainKey].ContainsKey(subKey)) return null;

            return _cache[mainKey][subKey];
        }
    }
}