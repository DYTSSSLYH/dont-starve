using System.Collections.Generic;
using DYT.Widgets;
using UnityEngine;
using Screen = DYT.Widgets.Screen;

namespace DYT.Screens
{
    public class BigPopupDialogScreen : Screen
    {
        public Menu menu { get; private set; }
        
        private Text title;
        private Text text;
        private List<Menu.MenuItem> buttons;

        public BigPopupDialogScreen Init(string title, string text, List<Menu.MenuItem> buttons,
            float timeout = 0, int? button_spacing = null, Vector3? title_pos = null)
        {
            base.Init();
            
            // title
            this.title = transform.Find("Title").GetComponent<Text>().Init(50);
            if (title_pos.HasValue) this.title.SetPosition(title_pos.Value);
            this.title.SetString(title);
            
            // text
            this.text = transform.Find("Text").GetComponent<Text>().Init(30);
            this.text.SetString(text);

            // create the menu itself
            int spacing = button_spacing.GetValueOrDefault(200);
            menu = transform.Find("Menu").GetComponent<Menu>().Init(buttons, spacing, true);
            menu.SetPosition(-(spacing * (buttons.Count - 1)) / 2f, -140, 0);
            this.buttons = buttons;
            default_focus = menu;
            
            return this;
        }

        
        
        public void OnClose()
        {
            Destroy(gameObject);
        }
    }
}