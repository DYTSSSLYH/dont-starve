using System;
using UnityEngine;
using UnityEngine.Events;

namespace DYT.Widgets
{
    public class Button : Widget
    {
        public Text text { get; set; }

        protected UnityEngine.UI.Button _textButton;
        private Color textcol;
        private Color textfocuscolour;
        private Vector3 clickoffset;

        protected UnityAction onclick;

        public override void Awake()
        {
            base.Awake();
            
            _textButton = transform.Find("Text").GetComponent<UnityEngine.UI.Button>();
        }

        public override void Start()
        {
            base.Start();
        }


        // base class for imagebuttons and animbuttons.
        public Button Init()
        {
            base.Init();
            
            text = transform.GetChild(0).GetComponent<Text>();

            textcol = new Color(0, 0, 0, 1);
            textfocuscolour = new Color(0, 0, 0, 1);
            clickoffset = new Vector3(0, -3, 0);
            
            return this;
        }

        public virtual void SetOnClick(UnityAction fn)
        {
            onclick = fn;
            _textButton.onClick.AddListener(() => onclick());
        }

        public void SetTextSize(float sz)
        {
            text.SetSize(sz);
        }

        public string GetText()
        {
            return text.GetString();
        }

        public void SetText(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg)) text.Hide();
            else
            {
                name = msg;
                text.SetString(msg);
                text.Show();
                text.SetColour(focus ? textfocuscolour : textcol);
            }
        }
    }
}