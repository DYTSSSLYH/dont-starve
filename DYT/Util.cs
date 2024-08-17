using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace DYT
{
    public static class Util
    {
        public static T GetRandomItem<T>(List<T> choices)
        {
            return choices[Random.Range(0, choices.Count)];
        }
        
        // concatenate two array-style tables
        public static List<T> JoinArrays<T>(params List<T>[] listArray)
        {
            List<T> result = new();
            foreach (List<T> list in listArray) result.AddRange(list);
        
            return result;
        }

        public static float GetRandomWithVariance(float baseval, float randomval)
        {
            return baseval + Random.Range(-1f, 1f) * randomval;
        }
        
        private static readonly Dictionary<string, string> _cachedFilePath = new();

        // look in package loaders to find the file from the root directories
        // this will look first in the mods and then in the data directory
        public static string resolvefilepath(string filepath)
        {
            if (_cachedFilePath.ContainsKey(filepath)) return _cachedFilePath[filepath];
            string resolved = softresolvefilepath(filepath);
            Debug.Assert(!string.IsNullOrWhiteSpace(resolved),
                $"Could not find an asset matching {filepath} in any of the search paths.");
            _cachedFilePath.Add(filepath, resolved);
            return resolved;
        }
        
        public static string softresolvefilepath(string filepath)
        {
            // it's already absolute, so just send it back
            if (Main.PLATFORM == "NACL" || Main.PLATFORM == "PS4") return filepath;
        
            // on PC platforms, search all the possible paths
        
            // mod folders don't have "data" in them, so we strip that off if necessary.
            // It will be added back on as one of the search paths.
            filepath = filepath.Replace("^/", "");
            string searchPath = Main.packagePath;
            string fileName = searchPath + filepath;
            if (File.Exists(fileName)) return fileName;

            return null;
        }

        
        #region MEMREPORT
        #endregion
        
        
        public static T[] shuffleArray<T>(T[] array)
        {
            int arrayLength = array.Length;
            for (int i = arrayLength - 1; i >= 1; i--)
            {
                int j = Random.Range(0, i);
                (array[i], array[j]) = (array[j], array[i]);
            }
            return array;
        }
        
        public static T deepcopy<T>(T obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }
    }
}