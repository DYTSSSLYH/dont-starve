using System.Collections.Generic;
using UnityEngine;

namespace DYT.Tools
{
    public static class ResourcesTool
    {
        private static readonly Dictionary<string, Sprite[]> _spriteCache = new();
        private static readonly Dictionary<string, Object> _objectCache = new();
        
        
        public static Sprite LoadSprite(string path, string spriteName)
        {
            if (!_spriteCache.ContainsKey(path)) _spriteCache.Add(path, Resources.LoadAll<Sprite>(path));
            
            Sprite[] result = _spriteCache[path];
        
            foreach (Sprite sprite in result)
            {
                if (sprite.name == spriteName) return sprite;
            }

            return null;
        }

        public static T Load<T>(string path) where T : Object
        {
            string name = path[(path.LastIndexOf('/') + 1)..];

            if (!_objectCache.ContainsKey(name)) _objectCache.Add(name, Resources.Load<T>(path));

            return (T)_objectCache[name];
        }
    }
}