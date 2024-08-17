using System.Collections.Generic;
using DYT.Widgets;
using Screen = DYT.Widgets.Screen;

namespace DYT.Screens
{
    public class PopupDialogScreen : Screen
    {
        private Image background;
        private Text title;
        private Text text;
        private Menu menu;
        private List<Menu.MenuItem> buttons;

        public PopupDialogScreen Init(string title, string text, List<Menu.MenuItem> buttons)
        {
            base.Init();
            
            // throw up the background
            background = transform.Find("Background").GetComponent<Image>();
            
            if (buttons.Count > 2) background.SetScale(2, 1.2f, 1.2f);
            
            // title
            this.title = transform.Find("Title").GetComponent<Text>();
            this.title.SetString(title);
            
            // text
            this.text = transform.Find("Text").GetComponent<Text>();
            
            this.text.SetString(text);

            int spacing = 200;
            
            menu = transform.Find("Menu").GetComponent<Menu>().Init(buttons, spacing, true);
            menu.SetPosition(-(spacing * (buttons.Count - 1)) / 2f, -70, 0);
            this.buttons = buttons;
            default_focus = menu;
            
            return this;
        }
        


        public void Cancel()
        {
            Destroy(gameObject);
        }
    }
}