using System.Collections.Generic;
using DYT.Widgets;
using UnityEngine;
using Screen = DYT.Widgets.Screen;

namespace DYT.Screens
{
    public class ScriptErrorScreen : Screen
    {
        public Menu menu { get; private set; }
        
        private UnityEngine.UI.Image background;
        private Text title;
        private Text text;
        private Text additionalText;
        private Text version;
        private TextButton disablemodwarning;
        private Image disablemodwarningimage;
        
        public ScriptErrorScreen Init(string title, string text, List<Menu.MenuItem> buttons,
            int? texthalign = null, string additionaltext = null,
            int? textsize = null, object timeout = null, bool showdisablemodwarning = false)
        {
            base.Init();
            
            // throw up the background
            background = transform.Find("Background").GetComponent<UnityEngine.UI.Image>();
            DLCSupport.SetBGcolor(background, true);
            
            // title
            Transform rootTransform = transform.Find("Root");
            this.title = rootTransform.Find("Title").GetComponent<Text>().Init(50);
            this.title.SetString(title);
            
            // text
            int defaulttextsize = 24;
            if (textsize.HasValue) defaulttextsize = textsize.Value;
            
            
            this.text = rootTransform.Find("Text").GetComponent<Text>().Init(defaulttextsize);

            if (texthalign.HasValue) this.text.SetHAlign(texthalign.Value);

            
            this.text.SetString(text);
            
            additionalText = rootTransform.Find("AdditionalText").GetComponent<Text>().Init(24);
            if (!string.IsNullOrWhiteSpace(additionaltext))
            {
                additionalText.gameObject.SetActive(true);
                additionalText.SetString(additionaltext);
            }

            version = transform.Find("Version").GetComponent<Text>().Init(20);
            version.SetString($"Rev. {Main.APP_VERSION} {Main.PLATFORM}");

            if (Main.PLATFORM != "PS4")
            {
                menu = rootTransform.Find("Menu").GetComponent<Menu>().Init(buttons, 200, true);
                menu.SetHRegPoint(Constant.ANCHOR_MIDDLE);
                default_focus = menu;
            }
            AddChild(Main.TheFrontEnd.helptext);

            disablemodwarning = rootTransform.Find("DisableModWarning").GetComponent<TextButton>().Init();
            if (showdisablemodwarning)
            {
                disablemodwarning.gameObject.SetActive(true);
                
                disablemodwarning.SetOnClick(() =>
                {
                    disablemodwarning.isChecked = !disablemodwarning.isChecked;
                    PlayerProfile.SetModsWarning(disablemodwarning.isChecked);
                    GameLogic.Profile.Save();
                    string texture = $"button_checkbox{(disablemodwarning.isChecked ? 2 : 1)}";
                    disablemodwarningimage.SetTexture("Images/ui", texture);
                });

                disablemodwarning.isChecked = !PlayerProfile.GetModsWarning();
                
                string texture = $"button_checkbox{(disablemodwarning.isChecked ? 2 : 1)}";
                disablemodwarningimage = disablemodwarning.transform.Find("DisableModWarningImage")
                    .GetComponent<Image>().Init("Images/ui", texture);

                float text_width = disablemodwarning.text.GetRegionSize().x;
                disablemodwarningimage.SetPosition(-0.5f * text_width - 10, -160);
                
                disablemodwarning.SetFocusChangeDir(Constant.MOVE_DOWN, menu);
                menu.SetFocusChangeDir(Constant.MOVE_UP, disablemodwarning);
            }

            return this;
        }


        public void DisableSubmitButton()
        {
            foreach (Widget menuItem in menu.items)
            {
                Button button = menuItem as Button;
                if (button && button.GetText() == "报告漏洞") button.Disable();
            }
        }
    }
}