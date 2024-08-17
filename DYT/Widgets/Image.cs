using DYT.Tools;
using UnityEngine;

namespace DYT.Widgets
{
    [RequireComponent(typeof(UnityEngine.UI.Image))]
    public class Image : Widget
    {
        public string atlas;
        public string tex;
        
        private UnityEngine.UI.Image ImageWidget;
        private string texture;

        public override void Awake()
        {
            base.Awake();
            
            ImageWidget = GetComponent<UnityEngine.UI.Image>();
        }

        public override void Start()
        {
            base.Start();
            
            Debug.Assert((string.IsNullOrWhiteSpace(atlas) && string.IsNullOrWhiteSpace(tex))
                         || (!string.IsNullOrWhiteSpace(atlas) && !string.IsNullOrWhiteSpace(tex)));

            if (!string.IsNullOrWhiteSpace(atlas) && !string.IsNullOrWhiteSpace(tex))
            {
                SetTexture(atlas, tex);
            }
        }
        
        public Image Init(string atlas = null, string tex = null)
        {
            return this;
        }

        public void SetTexture(string atlas, string tex)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(atlas));
            Debug.Assert(!string.IsNullOrWhiteSpace(tex));

            this.atlas = atlas;
            texture = tex;
            ImageWidget.sprite = ResourcesTool.LoadSprite(this.atlas, texture);
            ImageWidget.SetNativeSize();
        }

        public void SetTint(float r, float g, float b, float a)
        {
            ImageWidget.color = new Color(r, g, b, a);
        }
    }
}