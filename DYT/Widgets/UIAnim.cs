using UnityEngine;

namespace DYT.Widgets
{
    [RequireComponent(typeof(Animator))]
    public class UIAnim : Widget
    {
        private Animator AnimState;
        
        public override void Awake()
        {
            base.Awake();
            AnimState = GetComponent<Animator>();
        }

        public Animator GetAnimState()
        {
            return AnimState;
        }
    }
}