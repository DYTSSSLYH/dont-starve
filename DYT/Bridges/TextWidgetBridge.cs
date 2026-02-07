using DYT.Consts;
using TMPro;
using UnityEngine;

namespace DYT.Bridges
{
    public class TextWidgetBridge
    {
        private readonly TextMeshProUGUI _textMeshProUGUI;

        public TextWidgetBridge(TextMeshProUGUI textMeshProUGUI)
        {
            _textMeshProUGUI = textMeshProUGUI;
        }

        public void SetFont(string font)
        {
            _textMeshProUGUI.font = FontBridge.Instance._loadedFonts[font];
        }

        public void SetSize(int size)
        {
            _textMeshProUGUI.fontSize = size;
        }

        public void SetString(string text)
        {
            _textMeshProUGUI.text = text;
        }

        public void SetHAnchor(int anchor)
        {
            HorizontalAlignmentOptions horizontalAlignmentOptions = new HorizontalAlignmentOptions();

            switch (anchor)
            {
                case Const.ANCHOR_MIDDLE:
                    horizontalAlignmentOptions = HorizontalAlignmentOptions.Center;
                    break;
                case Const.ANCHOR_LEFT:
                    horizontalAlignmentOptions = HorizontalAlignmentOptions.Left;
                    break;
                case Const.ANCHOR_RIGHT:
                    horizontalAlignmentOptions = HorizontalAlignmentOptions.Right;
                    break;
            }
            
            _textMeshProUGUI.horizontalAlignment = horizontalAlignmentOptions;
        }

        public void SetVAnchor(int anchor)
        {
            VerticalAlignmentOptions verticalAlignmentOptions = new VerticalAlignmentOptions();

            switch (anchor)
            {
                case Const.ANCHOR_MIDDLE:
                    verticalAlignmentOptions = VerticalAlignmentOptions.Middle;
                    break;
                case Const.ANCHOR_TOP:
                    verticalAlignmentOptions = VerticalAlignmentOptions.Top;
                    break;
                case Const.ANCHOR_BOTTOM:
                    verticalAlignmentOptions = VerticalAlignmentOptions.Bottom;
                    break;
            }
            
            _textMeshProUGUI.verticalAlignment = verticalAlignmentOptions;
        }

        public void SetRegionSize(int w, int h)
        {
            RectTransform rectTransform = _textMeshProUGUI.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(w, h);
        }
    }
}