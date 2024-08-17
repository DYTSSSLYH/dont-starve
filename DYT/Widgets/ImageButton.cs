using DYT.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DYT.Widgets
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class ImageButton : Button
    {
        public string atlas;
        public string image_normal;
        public string image_focus;
        public string image_disabled;

        private UnityEngine.UI.Button _imageButton;
        private Image image;

        public override void Awake()
        {
            base.Awake();
            
            _imageButton = GetComponent<UnityEngine.UI.Button>();
            image = transform.Find("Image").GetComponent<Image>();
        }

        public override void Start()
        {
            base.Start();
            
            if (!string.IsNullOrWhiteSpace(atlas)) image.SetTexture(atlas, image_normal);
            
            SpriteState spriteState = _imageButton.spriteState;
            if (!string.IsNullOrWhiteSpace(image_focus))
            {
                spriteState.highlightedSprite = ResourcesTool.LoadSprite(atlas, image_focus);
                spriteState.pressedSprite = spriteState.highlightedSprite;
                spriteState.selectedSprite = spriteState.highlightedSprite;
            }
            if (!string.IsNullOrWhiteSpace(image_disabled))
            {
                spriteState.disabledSprite = ResourcesTool.LoadSprite(atlas, image_disabled);
            }
            _imageButton.spriteState = spriteState;
        }
        
        public ImageButton Init(string atlas = null,
            string normal = null, string focus = null, string disabled = null)
        {
            base.Init();
            base.Init();

            image = GetComponent<Image>();
            image.MoveToBack();

            return this;
        }

        public override void SetOnClick(UnityAction fn)
        {
            base.SetOnClick(fn);
            _imageButton.onClick.AddListener(() => onclick());
        }

        public override void Enable()
        {
            base.Enable();
            // self.image:SetTexture(self.atlas, self.focus and self.image_focus or self.image_normal)
            _textButton.interactable = true;

            if (image_focus == image_normal)
            {
                if (focus) image.SetScale(1.2f, 1.2f, 1.2f);
                else image.SetScale(1, 1, 1);
            }
        }

        public override void Disable()
        {
            base.Disable();
            // image.SetTexture(atlas, image_disabled);
            _textButton.interactable = false;
        }
    }
}