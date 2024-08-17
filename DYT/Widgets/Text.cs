using TMPro;
using UnityEngine;

namespace DYT.Widgets
{
    public class Text : Widget
    {
        public TextMeshProUGUI TextWidget { get; private set; }
        public bool? closeonrun { get; set; }
        public bool shown { get; private set; }
        
        public string size;
        public string text;

        private string str;
        private float realSize;

        public override void Awake()
        {
            base.Awake();
            TextWidget = GetComponent<TextMeshProUGUI>();
        }

        public override void Start()
        {
            base.Start();

            if (!string.IsNullOrWhiteSpace(size))
            {
                realSize = int.Parse(size);
                TextWidget.fontSize = realSize;
            }
            
            if (!string.IsNullOrWhiteSpace(text)) SetString(text);
        }

        public Text Init(int size, string text = null)
        {
            return this;
        }
        
        
        public void SetColour(Color color)
        {
            TextWidget.color = color;
        }
        public void SetColour(float r, float g, float b, float a)
        {
            SetColour(new Color(r, g, b, a));
        }
        
        public void SetAlpha(float a)
        {
            TextWidget.color = new Color(1, 1, 1, a);
        }

        public void SetSize(float sz)
        {
            sz *= Loc.GetTextScale();
            TextWidget.fontSize = sz;
            realSize = sz;
        }

        public Vector2 GetRegionSize()
        {
            return TextWidget.rectTransform.rect.size;
        }
        
        public virtual void SetString(string str)
        {
            this.str = str;
            TextWidget.text = string.IsNullOrWhiteSpace(str) ? "" : str;
        }

        public virtual string GetString()
        {
            return TextWidget.text;
        }
        
        public void SetVAlign(int anchor)
        {
            if (anchor == Constant.ANCHOR_MIDDLE)
            {
                TextWidget.verticalAlignment = VerticalAlignmentOptions.Middle;
            }
            else if (anchor == Constant.ANCHOR_TOP)
            {
                TextWidget.verticalAlignment = VerticalAlignmentOptions.Top;
            }
            else if (anchor == Constant.ANCHOR_BOTTOM)
            {
                TextWidget.verticalAlignment = VerticalAlignmentOptions.Bottom;
            }
        }
        
        public void SetHAlign(int anchor)
        {
            if (anchor == Constant.ANCHOR_MIDDLE)
            {
                TextWidget.horizontalAlignment = HorizontalAlignmentOptions.Center;
            }
            else if (anchor == Constant.ANCHOR_LEFT)
            {
                TextWidget.horizontalAlignment = HorizontalAlignmentOptions.Left;
            }
            else if (anchor == Constant.ANCHOR_RIGHT)
            {
                TextWidget.horizontalAlignment = HorizontalAlignmentOptions.Right;
            }
        }
    }
}