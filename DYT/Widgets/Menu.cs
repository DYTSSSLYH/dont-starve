using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DYT.Widgets
{
    public class Menu : Widget
    {
        public List<Widget> items { get; set; }
        
        private int offset;
        public class MenuItem
        {
            public Widget widget;
            public string text;
            public UnityAction cb;
            public Vector3 offset;
            public bool disable;

            public bool nopop;
        }
        private bool horizontal;

        private int? textSize;
        
        public Menu Init(List<MenuItem> menuitems, int offset, bool horizontal)
        {
            this.offset = offset;
            items = new List<Widget>();
            this.horizontal = horizontal;

            if (menuitems != null)
            {
                foreach (MenuItem menuItem in menuitems)
                {
                    if (menuItem.widget) AddCustomItem(menuItem.widget, menuItem.offset);
                    else
                    {
                        ImageButton new_btn = AddItem(menuItem.text, menuItem.cb, menuItem.offset);
                        if (menuItem.disable) new_btn.Disable();
                    }
                }
            }

            return this;
        }

        public void SetHRegPoint(int halign)
        {
            Vector3 pos = Vector3.zero;
            if (halign == Constant.ANCHOR_MIDDLE)
            {
                pos = new Vector3(offset * (items.Count - 1) * -0.5f, 0, 0);
            }
            else if (halign == Constant.ANCHOR_RIGHT)
            {
                pos = new Vector3(offset * (items.Count - 1) * -1, 0, 0);
            }
            
            foreach (Widget widget in items)
            {
                widget.SetPosition(pos);
                pos.x += offset;
            }
        }

        public Widget AddCustomItem(Widget widget, Vector3? offset = null)
        {
            Vector3 pos = Vector3.zero;
            if (horizontal) pos.x += this.offset * items.Count;
            else pos.y += this.offset * items.Count;
            if (offset.HasValue) pos += offset.Value;
            AddChild(widget);
            widget.SetPosition(pos);
            items.Add(widget);
            widget.DoFocusHookups();
            return widget;
        }

        public ImageButton AddItem(string text, UnityAction cb, Vector3? offset,
            object style = null, int? textsize = null)
        {
            Vector3 pos = Vector3.zero;
            
            if (horizontal) pos.x += this.offset * items.Count;
            else pos.y += this.offset * items.Count;
            
            if (offset.HasValue) pos += offset.Value;

            textsize = textsize.GetValueOrDefault(1);

            GameObject instantiate = Instantiate(transform.GetChild(0).gameObject);
            instantiate.SetActive(true);
            ImageButton button = (ImageButton)AddChild(instantiate.GetComponent<ImageButton>().Init());
            button.SetPosition(pos);
            button.SetText(text);
            button.SetOnClick(cb);
            if (textSize.HasValue) button.SetTextSize(textSize.Value * textsize.Value);
            else button.SetTextSize(40 * textsize.Value);
            items.Add(button);
            
            DoFocusHookups?.Invoke();
            return button;
        }
    }
}