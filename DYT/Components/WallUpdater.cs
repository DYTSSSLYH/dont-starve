using System;
using UnityEngine;

namespace DYT.Components
{
    [RequireComponent(typeof(EntityScript))]
    public class WallUpdater : MonoBehaviour
    {
        public EntityScript inst;
        
        private Action<object, float> wallupdatefunc;

        public void Start()
        {
            inst = GetComponent<EntityScript>();
        }
        
        public void StartWallUpdating(Action<object, float> func)
        {
            if (func != null) wallupdatefunc = func;
            inst.StartWallUpdatingComponent(this);
        }
    }
}