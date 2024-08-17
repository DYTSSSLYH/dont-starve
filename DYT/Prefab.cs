using System.Collections.Generic;
using UnityEngine;

namespace DYT
{
    [RequireComponent(typeof(EntityScript))]
    public class Prefab : MonoBehaviour
    {
        public List<string> deps { get; set; } = new List<string>();
        
        
        public string name;
        

        protected EntityScript inst;
        
        private string _path;
        private string _desc = "";
        
        
        private void Start()
        {
            inst = GetComponent<EntityScript>();
            _path = string.IsNullOrWhiteSpace(name) ? null : name;
            name = name[(name.LastIndexOf('/') + 1)..];
        }
    }
}