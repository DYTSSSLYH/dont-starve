using System;
using UnityEngine;

namespace DYT.Components
{
    [RequireComponent(typeof(EntityScriptSelf))]
    public class WallUpdater : MonoBehaviour
    {
        public EntityScriptSelf inst;
        
        private Action<object, float> wallupdatefunc;

        public void Start()
        {
            inst = GetComponent<EntityScriptSelf>();
        }
        
        public void StartWallUpdating(Action<object, float> func)
        {
            if (func != null) wallupdatefunc = func;
            inst.StartWallUpdatingComponent(this);
        }
    }
}