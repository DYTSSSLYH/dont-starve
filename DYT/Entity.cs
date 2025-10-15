using System;
using System.Collections.Generic;
using UnityEngine;

namespace DYT
{
    public class Entity
    {
        private readonly GameObject _gameObject;
        private List<string> _tagList = new List<string>();
        
        public Entity(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public int GetGUID()
        {
            return _gameObject.GetInstanceID();
        }

        public void SetCanSleep(bool canSleep)
        {
            
        }

        public void AddTransform()
        {
            if (_gameObject.transform) return;
            
            _gameObject.AddComponent<Transform>();
        }

        public void AddTag(string tag)
        {
            _tagList.Add(tag);
        }
        public void RemoveTag(string tag)
        {
            _tagList.Remove(tag);
        }
        public bool HasTag(string tag)
        {
            return _tagList.Contains(tag);
        }
    }
}