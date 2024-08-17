using System;
using System.Collections.Generic;
using DYT.Components;
using DYT.Widgets;
using UnityEngine;
using Screen = DYT.Widgets.Screen;

namespace DYT.Screens
{
    public class BugReportScreen : Screen
    {
        private static string VALID_CHARS = @"[ a-zA-Z0-9.,:;\[\]\@!#$%&()'*+-/=?^_{|}~" + "\"]";
        
        public GameObject cancelSubmitPopupDialogScreen;
        public GameObject submitDialogBigPopupDialogScreen;
        public GameObject submittingBugReportPopup;
        
        private bool needsUnPause;
        private Text description_text;
        private ImageButton cancel_button;
        private ImageButton submit_button;
        private ImageButton edit_button;
        private Image editroot;
        private TextEdit console_edit;

        private float waitTime;
        private Action waitFn;
        
        public BugReportScreen Init()
        {
            base.Init();

            if (!MainFunctions.IsPaused())
            {
                MainFunctions.SetPause(true, "bugreport");
                needsUnPause = true;
            }

            description_text = transform.Find("DescriptionText").GetComponent<Text>().Init(30, "");

            cancel_button = transform.Find("CancelButton").GetComponent<ImageButton>().Init();
            cancel_button.SetOnClick(CancelButton);

            submit_button = transform.Find("CancelButton").GetComponent<ImageButton>().Init();
            submit_button.SetOnClick(FileBugReportButton);

            edit_button = transform.Find("EditButton").GetComponent<ImageButton>();
            edit_button.SetOnClick(EditDescription);

            editroot = transform.Find("EditRoot").GetComponent<Image>();

            console_edit = transform.Find("EditRoot").Find("ConsoleEdit").GetComponent<TextEdit>();
            console_edit.OnTextInput = text =>
            {
                string s = text.Replace('\n', ' ').Replace('\r', ' ');
                console_edit.SetString(s);
                description_text.SetString(s);
            };
            console_edit.TextEditWidget.onValueChanged.AddListener(
                text => console_edit.OnTextInput(text));
            console_edit.OnTextEntered = OnTextEntered;
            console_edit.SetCharacterFilter(VALID_CHARS);
            console_edit.SetAllowClipboardPaste(true);

            WallUpdater wallUpdater = GetComponent<WallUpdater>();
            inst.AddComponent("wallupdater", wallUpdater);
            wallUpdater.StartWallUpdating((_self, dt) => OnWallUpdate(dt));
            
            return this;
        }

        public void OnWallUpdate(float dt)
        {
            if (waitFn != null)
            {
                waitTime -= dt;
                if (waitTime <= 0)
                {
                    waitFn();
                    waitFn = null;
                }
            }

            if (editroot.IsVisible() && !console_edit.editing)
            {
                // hack, canceling on controller while editing doesn't hide the editroot
                OnTextEntered();
            }
        }

        public void UnPauseIfNeeded()
        {
            if (needsUnPause) MainFunctions.SetPause(false);
        }

        // Hack, since this screen can run after an error is thrown there's no update
        // and thus no DoTaskInTime
        public void DoTaskInTime_Hack(float time, Action func)
        {
            waitTime = time;
            waitFn = func;
        }

        public void OnTextEntered()
        {
            string str = console_edit.GetString().Trim();
            if (string.IsNullOrWhiteSpace(str))
            {
                description_text.SetColour(1, 1, 1, 1);
                description_text.SetString("请输入一些描述...");
                edit_button.SetText("输入错误描述");
                submit_button.Disable();
            }
            else
            {
                description_text.SetColour(0.7f, 0.7f, 0.7f, 1);
                description_text.SetString(str);
                edit_button.SetText("更改错误描述");
                submit_button.Enable();
            }
            
            editroot.Hide();
            
            TheInputProxy.FlushInput();
            edit_button.Enable();
            DoTaskInTime_Hack(0.1f, () =>
            {
                Main.TheFrontEnd.LockFocus(false);
                SetFocus();
            });
        }

        public void EditDescription()
        {
            edit_button.Disable();
            
            editroot.Show();
            
            console_edit.SetFocus();
            console_edit.SetEditing(true);
            Main.TheFrontEnd.LockFocus(true);
        }

        public void CancelButton()
        {
            string str = description_text.GetString().Trim();
            if (!string.IsNullOrWhiteSpace(str))
            {
                Main.TheFrontEnd.PushScreen(Instantiate(cancelSubmitPopupDialogScreen)
                    .GetComponent<PopupDialogScreen>().Init("取消错误报告？", "报告还未提交。\n确定要取消吗？",
                        new List<Menu.MenuItem>
                        {
                            new(){text = "否", cb = () => Main.TheFrontEnd.PopScreen()},
                            new(){text = "是", cb = () =>
                                {
                                    UnPauseIfNeeded();
                                    Main.TheFrontEnd.PopScreen();
                                    Main.TheFrontEnd.PopScreen();
                                }
                            }
                        }), true);
            }
            else
            {
                UnPauseIfNeeded();
                Main.TheFrontEnd.PopScreen(this);
            }
        }

        public void FileBugReportButton()
        {
            BigPopupDialogScreen bigPopupDialogScreen = Instantiate(submitDialogBigPopupDialogScreen)
                .GetComponent<BigPopupDialogScreen>().Init("提交错误报告？",
                    "提交错误报告会向科雷公司上传你的游戏信息和存储的世界，以帮助我们分析问题。\n\n" +
                    "整个过程可能需要几分钟。", new List<Menu.MenuItem>
                    {
                        new(){text = "提交", cb = () =>
                        {
                            Main.TheFrontEnd.PopScreen();
                            FileBugReport();
                        }},
                        new(){text = "取消", cb = () => Main.TheFrontEnd.PopScreen()}
                    });
            
            Main.TheFrontEnd.PushScreen(bigPopupDialogScreen, true);
        }

        public void FileBugReport()
        {
            TheSim.FileBugReport(description_text.GetString());
            Main.TheFrontEnd.PushScreen(Instantiate(submittingBugReportPopup)
                .GetComponent<SubmittingBugReportPopup>().Init(needsUnPause), true);
        }
    }
}