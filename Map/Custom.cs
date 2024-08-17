using System.Collections.Generic;

public class Custom
{
    public class CustomiseItem
    {
        public string value;
        public List<Spinner.SpinnerOption> spinnerOptionList;
        public bool enable;
        public string atlas;
        public string image;


        public CustomiseItem(string value, List<Spinner.SpinnerOption> spinnerOptionList,
            bool enable, string atlas, string image)
        {
            this.value = value;
            this.spinnerOptionList = spinnerOptionList;
            this.enable = enable;
            this.atlas = atlas;
            this.image = image;
        }
    }
    public class CustomiseGroup
    {
        public string text;
        public List<Spinner.SpinnerOption> spinnerOptionList;
        public bool enable;
        public Dictionary<string, CustomiseItem> itemDictionary;


        public CustomiseGroup(string text, List<Spinner.SpinnerOption> spinnerOptionList,
            bool enable, Dictionary<string, CustomiseItem> itemDictionary)
        {
            this.text = text;
            this.spinnerOptionList = spinnerOptionList;
            this.enable = enable;
            this.itemDictionary = itemDictionary;
        }
    }


    public Dictionary<string, CustomiseGroup> group;
}