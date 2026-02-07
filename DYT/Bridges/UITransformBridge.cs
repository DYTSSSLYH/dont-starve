using DYT.Consts;
using UnityEngine;
using UnityEngine.UI;
using XLua;

namespace DYT.Bridges
{
    public class UITransformBridge
    {
        private readonly RectTransform _rectTransform;
        private readonly LuaTable _inst;

        public UITransformBridge(RectTransform rectTransform, LuaTable inst)
        {
            _rectTransform = rectTransform;
            _inst = inst;
        }

        public void SetHAnchor(int anchor)
        {
            Vector2 anchorMin = _rectTransform.anchorMin;
            Vector2 anchorMax = _rectTransform.anchorMax;
            if (anchor == Const.ANCHOR_MIDDLE)
            {
                anchorMin.x = 0.5f;
                anchorMax.x = 0.5f;
            }
            else if (anchor == Const.ANCHOR_LEFT)
            {
                anchorMin.x = 0;
                anchorMax.x = 0;
            }
            else if (anchor == Const.ANCHOR_RIGHT)
            {
                anchorMin.x = 1;
                anchorMax.x = 1;
            }
            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;
        }
        
        public void SetVAnchor(int anchor)
        {
            Vector2 anchorMin = _rectTransform.anchorMin;
            Vector2 anchorMax = _rectTransform.anchorMax;
            
            if (anchor == Const.ANCHOR_BOTTOM)
            {
                anchorMin.y = 0;
                anchorMax.y = 0;
            }
            else if (anchor == Const.ANCHOR_MIDDLE)
            {
                anchorMin.y = 0.5f;
                anchorMax.y = 0.5f;
            }
            else if (anchor == Const.ANCHOR_TOP)
            {
                anchorMin.y = 1;
                anchorMax.y = 1;
            }
            
            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;
        }

        public void SetScaleMode(int mode)
        {
            string modeStr = null;

            switch (mode)
            {
                case Const.SCALEMODE_NONE:
                    modeStr = nameof(Const.ScaleMode.SCALEMODE_NONE);
                    break;
                case Const.SCALEMODE_FILLSCREEN:
                    _rectTransform.sizeDelta = new Vector2(Const.RESOLUTION_X, Const.RESOLUTION_Y);
                    return;
                case Const.SCALEMODE_PROPORTIONAL:
                    modeStr = nameof(Const.ScaleMode.SCALEMODE_PROPORTIONAL);
                    break;
                case Const.SCALEMODE_FIXEDPROPORTIONAL:
                    modeStr = nameof(Const.ScaleMode.SCALEMODE_FIXEDPROPORTIONAL);
                    break;
                case Const.SCALEMODE_FIXEDSCREEN_NONDYNAMIC:
                    modeStr = nameof(Const.ScaleMode.SCALEMODE_FIXEDSCREEN_NONDYNAMIC);
                    break;
            }
            
            LuaTable widget = _inst.Get<LuaTable>("widget");
            string widgetName = widget.Get<string>("name");
            
            Debug.Log(
                $"UITransformBridge.cs -> SetScaleMode() -> widgetName:{widgetName}, mode:{modeStr}"
            );
        }

        public void SetPosition(int x, int y, int z)
        {
            _rectTransform.anchoredPosition3D = new Vector3(x, y, z);
        }

        public void UpdateTransform()
        {
            Image image = _rectTransform.GetComponent<Image>();
            
            if (image == null) return;
            
            _rectTransform.sizeDelta = new Vector2(image.sprite.rect.width, image.sprite.rect.height);
        }

        public void SetScale(float x, float y, float z)
        {
            _rectTransform.localScale = new Vector3(x, y, z);
        }
    }
}