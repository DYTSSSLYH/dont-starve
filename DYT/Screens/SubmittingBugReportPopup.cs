using System.Collections.Generic;
using DYT.Components;
using DYT.Widgets;
using UnityEngine;
using Screen = DYT.Widgets.Screen;

namespace DYT.Screens
{
    public class SubmittingBugReportPopup : Screen
    {
        public GameObject popupDialogScreen;
        
        private bool needsUnPause;
        private Text text;
        private int time;
        private int progress;
        private float step_time;
        private int elipse_state;
        
        public SubmittingBugReportPopup Init(bool needsUnPause)
        {
            base.Init();

            this.needsUnPause = needsUnPause;

            text = transform.Find("Text").GetComponent<Text>();

            time = 0;
            progress = 0;

            step_time = 0;
            elipse_state = 0;
            
            // Hack, we can be showing with the bugreportscreen, there is no OnUpdate then
            WallUpdater wallUpdater = GetComponent<WallUpdater>();
            inst.AddComponent("wallupdater", wallUpdater);
            wallUpdater.StartWallUpdating((_self, dt) => OnWallUpdate(dt));
            
            return this;
        }

        public void OnWallUpdate(float dt)
        {
            int NEXT_STATE = 1;
            step_time += dt;

            if (step_time > NEXT_STATE)
            {
                if (elipse_state == 0)
                {
                    text.SetString("正在提交文件，请等候。..");
                    elipse_state += 1;
                }
                else if (elipse_state == 1)
                {
                    text.SetString("正在提交文件，请等候。...");
                    elipse_state += 1;
                }
                else
                {
                    text.SetString("正在提交文件，请等候。.");
                    elipse_state = 0;
                }
                step_time = 0;
            }
            
            // did we finish?
            if (!TheSim.IsBugReportRunning())
            {
                string title = "错误";
                string text = "文件上传出错。";

                bool succeed = TheSim.DidBugReportSucceed();

                if (succeed)
                {
                    title = "成功";
                    text = "文件上传成功。感谢你的帮助。";
                }

                PopupDialogScreen popup = Instantiate(popupDialogScreen).GetComponent<PopupDialogScreen>()
                    .Init(title, text, new List<Menu.MenuItem>
                    {
                        new(){text = "好的", cb = () =>
                        {
                            Main.TheFrontEnd.PopScreen();
                            if (needsUnPause) MainFunctions.SetPause(false);
                            if (succeed)
                            {
                                // if the error screen is visible, disable the "submit bug" button
                                Main.TheFrontEnd.PopScreen();
                                if (Main.TheFrontEnd.IsDisplayingError())
                                {
                                    Screen screen = Main.TheFrontEnd.GetActiveScreen();
                                    ScriptErrorScreen scriptErrorScreen = screen as ScriptErrorScreen;
                                    if (scriptErrorScreen) scriptErrorScreen.DisableSubmitButton();
                                }
                            }
                        }}
                    });

                Main.TheFrontEnd.PopScreen();
                Main.TheFrontEnd.PushScreen(popup, true);
            }
        }
    }
}