using System;
using TMPro;
using UnityEngine;

namespace DYT.Widgets
{
    [RequireComponent(typeof(TMP_InputField))]
    public class TextEdit : Text
    {
        public Action OnTextEntered { get; set; }
        public Action<string> OnTextInput { get; set; }
        public TMP_InputField TextEditWidget { get; private set; }
        public bool editing { get; private set; }
        
        private Image focusimage;
        private string atlas;
        private string focusedtex;
        private string unfocusedtex;
        private int limit;
        private string validchars;

        public override void Awake()
        {
            base.Awake();

            TextEditWidget = GetComponent<TMP_InputField>();
        }

        public override void Start()
        {
            base.Start();

            if (!string.IsNullOrWhiteSpace(size)) TextEditWidget.pointSize = int.Parse(size);
            if (!string.IsNullOrWhiteSpace(text)) TextEditWidget.text = text;
        }

        public override string GetString()
        {
            return TextEditWidget.text;
        }

        public override void SetString(string str)
        {
            TextEditWidget.text = str;
        }

        public void SetEditing(bool editing)
        {
            if (editing) SetFocus();
            this.editing = editing;
            TextEditWidget.interactable = this.editing;
        }

        public void SetFocusedImage(string atlas, string focused, string unfocused)
        {
            focusimage = GetComponent<Image>();
            this.atlas = atlas;
            focusedtex = focused;
            unfocusedtex = unfocused;

            if (!string.IsNullOrWhiteSpace(focusedtex) && !string.IsNullOrWhiteSpace(unfocusedtex))
            {
                focusimage.SetTexture(this.atlas, focus ? focusedtex : unfocusedtex);
            }
        }

        public void SetTextLengthLimit(int limit)
        {
            this.limit = limit;
        }

        public void SetCharacterFilter(string validchars)
        {
            this.validchars = validchars;
        }
        
        public void SetAllowClipboardPaste(bool to){}
    }
}