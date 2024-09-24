using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DYT;
using DYT.Map;
using DYT.Screens;
using DYT.Tools;
using DYT.Widgets;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class CustomScreen : MonoBehaviour
{
    public int world { get; set; }
    public Action<ChangedOption> saveHandler { get; set; }
    public class ChangedOption
    {
        public SpinnerOption preset { get; }
        public Dictionary<string, string> optionList { get; }
        public bool ROGEnabled;
        public int level_id;

        public ChangedOption(){}
        public ChangedOption(SpinnerOption preset, Dictionary<string, string> optionList)
        {
            this.preset = preset;
            this.optionList = optionList;
        }
    }
    public ChangedOption defaultChangedOption { get; set; }

    
    public Image background;

    public int maxCustomPresetNum = 5;
    public TextMeshProUGUI presetDescription;
    public Spinner presetSpinner;

    public Transform realPanel;
    public int optionOffset = 0;
    public int optionCountPerScreen;
    public Button leftButton;
    public Button rightButton;

    public GameObject invalidOptionPopupDialogScreen;
    public GameObject confirmRevertPopupDialogScreen;


    private class SettingOption
    {
        public string name { get; }
        public string atlas { get; }
        public string image { get; }
        public string defaultValue { get; }
        public List<SpinnerOption> spinnerOptionList { get; }


        public SettingOption(string name, string atlas, string image, string defaultValue,
            List<SpinnerOption> spinnerOptionList)
        {
            this.name = name;
            this.atlas = atlas;
            this.image = image;
            this.defaultValue = defaultValue;
            this.spinnerOptionList = spinnerOptionList;
        }
    }
    private List<SettingOption> _settingOptionList;
    
    private int _defaultPresetNum;
    private List<Level> _customPresetList;
    private List<SpinnerOption> _presetList;
    
    private bool _presetDirty;
    private ChangedOption _nowChangedOption;


    private void Reset()
    {
        background = GetComponent<Image>();
        
        presetDescription = transform.Find("PresetPanel").Find("Description").GetComponent<TextMeshProUGUI>();
        presetSpinner = transform.Find("PresetPanel").Find("Spinner").GetComponent<Spinner>();
        
        realPanel = transform.Find("OptionsPanel").Find("RealPanel");
        optionCountPerScreen = realPanel.childCount;
        leftButton = transform.Find("OptionsPanel").Find("LeftButton").GetComponent<Button>();
        rightButton = transform.Find("OptionsPanel").Find("RightButton").GetComponent<Button>();
    }
    
    private void MakePresetDirty()
    {
        _presetDirty = true;

        presetDescription.text = "Your world, your rules!";
        presetSpinner.UpdateText($"{_nowChangedOption.preset.text} (Custom)");
    }
    private void RefreshOptions()
    {
        for (int i = 0; i < optionCountPerScreen; i++)
        {
            int index = optionOffset + i;
            Transform option = realPanel.GetChild(i);
            if (index >= _settingOptionList.Count)
            {
                option.gameObject.SetActive(false);
                continue;
            }
            
            option.gameObject.SetActive(true);
            SettingOption nowSettingOption = _settingOptionList[index];
            GameObject optionBackground = option.Find("Background").gameObject;
            
            Image image = option.Find("Image").GetComponent<Image>();
            image.sprite = ResourcesTool.LoadSprite(nowSettingOption.atlas, nowSettingOption.image);
            string upperCaseName = nowSettingOption.name.ToUpper();
            Type type = typeof(STRINGS.NAMES);
            FieldInfo fieldInfo = type.GetField(upperCaseName);
            Type type1 = typeof(STRINGS.UI.CUSTOMIZATIONSCREEN.NAMES);
            FieldInfo fieldInfo1 = type1.GetField(upperCaseName);
            string tooltip = (string)(fieldInfo != null ? fieldInfo.GetValue(null) :
                fieldInfo1 != null ? fieldInfo1.GetValue(null) : nowSettingOption.name);

            
            Spinner spinner = option.Find("Spinner").GetComponent<Spinner>();
            spinner.SetOptions(nowSettingOption.spinnerOptionList);
            
            object defaultValue =
                ((Dictionary<string, string>)_nowChangedOption.preset.otherInfoDictionary["overrides"])
                .TryGetValue(nowSettingOption.name, out string overrideValue) ?
                overrideValue : nowSettingOption.defaultValue;
            
            spinner.SetSelected(defaultValue);
            
            if (_nowChangedOption.optionList.TryGetValue(nowSettingOption.name, out string changedValue))
                spinner.SetSelected(changedValue);
            
            spinner.onChanged = (oldData, newData) =>
            {
                if (newData == defaultValue)
                {
                    if (!_nowChangedOption.optionList.ContainsKey(nowSettingOption.name)) return;
                    
                    _nowChangedOption.optionList.Remove(nowSettingOption.name);

                    
                    optionBackground.SetActive(false);
                    if (_nowChangedOption.optionList.Count == 0) LoadPreset(presetSpinner.GetSelectedData());
                }
                else
                {
                    _nowChangedOption.optionList[nowSettingOption.name] = newData as string;
                    
                    
                    optionBackground.SetActive(true);
                    if (!_presetDirty) MakePresetDirty();
                }
            };
        }
    }
    private void Scroll(int dir)
    {
        optionOffset += dir;
        
        RefreshOptions();


        leftButton.interactable = true;
        rightButton.interactable = true;

        if (optionOffset <= 0) leftButton.interactable = false;
        if (optionOffset + optionCountPerScreen >= _settingOptionList.Count) rightButton.interactable = false;
    }
    private void LoadPreset(object presetId)
    {
        foreach (SpinnerOption preset in _presetList)
        {
            if (preset.data == presetId)
            {
                presetDescription.text = (string)preset.otherInfoDictionary["description"];
                
                
                _presetDirty = false;
                
                _nowChangedOption = new ChangedOption(preset, new Dictionary<string, string>());
                
                if (presetId == defaultChangedOption.preset.data) _nowChangedOption = defaultChangedOption;
                
                
                Scroll(0);
                
                return;
            }
        }
    }
    private void Start()
    {
        Debug.Log($"{DLCSupport.CAPY_DLC} {DLCSupport.REIGN_OF_GIANTS} {DLCSupport.PORKLAND_DLC}");
        DLCSupport.SetManualBGColor(background, world);
        
        #region 设置选项setting_option初始化
        
        Customise custom = new CustomiseBase();
        if (world == DLCSupport.MAIN_GAME) custom = new CustomiseBase();
        else if (world == DLCSupport.REIGN_OF_GIANTS) custom = new CustomiseRog();
        else if (world == DLCSupport.CAPY_DLC) custom = new CustomSw();
        else if (world == DLCSupport.PORKLAND_DLC) custom = new CustomisePork();

        _settingOptionList = new List<SettingOption>();
        foreach (string groupName in custom.GROUP.Keys)
        {
            CustomiseGroup group = custom.GROUP[groupName];
            Dictionary<string,CustomiseItem> itemDictionary = group.items;
            foreach (string itemName in itemDictionary.Keys)
            {
                CustomiseItem item = itemDictionary[itemName];
                
                _settingOptionList.Add(new SettingOption(itemName,
                    item.atlas == null ? "Images/customisation" : item.atlas, item.image, item.value,
                    item.spinner == null ? group.desc : item.spinner));
            }
        }
        
        #endregion

        #region 预设preset相关操作
        
        _presetList = new List<SpinnerOption>();
        
        List<Level> levelPresetList = new List<Level>();
        if (world == DLCSupport.MAIN_GAME) levelPresetList = Levels.sandbox_levels;
        else if (world == DLCSupport.REIGN_OF_GIANTS) levelPresetList = Levels.sandbox_levels;
        else if (world == DLCSupport.CAPY_DLC) levelPresetList = Levels.shipwrecked_levels;
        else if (world == DLCSupport.PORKLAND_DLC) levelPresetList = Levels.porkland_levels;
        _defaultPresetNum = levelPresetList.Count;
        foreach (Level levelPreset in levelPresetList)
        {
            _presetList.Add(new SpinnerOption(levelPreset.name, levelPreset.id,
                new Dictionary<string, object> {
                    {"description", levelPreset.desc},
                    {"overrides", levelPreset.overrides}
                }
            ));
        }

        _customPresetList = GameLogic.Profile.GetWorldCustomizationPresets(world);
        foreach (Level customPreset in _customPresetList)
        {
            _presetList.Add(new SpinnerOption(customPreset.name, customPreset.id,
                new Dictionary<string, object> {
                    {"description", customPreset.desc},
                    {"overrides", customPreset.overrides}
                }
            ));
        }

        presetSpinner.SetOptions(_presetList);

        #endregion

        
        if (defaultChangedOption == null)
            defaultChangedOption = new ChangedOption(_presetList[0], new Dictionary<string, string>());

        LoadPreset(defaultChangedOption.preset.data);


        presetSpinner.onChanged = (oldData, newData) =>
        {
            if (_presetDirty)
            {
                Instantiate(confirmRevertPopupDialogScreen, transform.parent)
                    .GetComponent<PopupDialogScreen>().Init("Lose Changes?",
                        "Apply a new preset and lose custom changes?", new List<Menu.MenuItem>
                        {
                            new(){text = "Yes", cb = () =>
                            {
                                Main.TheFrontEnd.PopScreen();
                                optionOffset = 0;
                                LoadPreset(newData);
                            }}
                        });
            }
            else
            {
                optionOffset = 0;
                LoadPreset(newData);
            }
        };
        
        leftButton.onClick.AddListener(() => Scroll(-optionCountPerScreen));
        rightButton.onClick.AddListener(() => Scroll(optionCountPerScreen));
    }


    private bool PendingChanges()
    {
        if (_nowChangedOption.preset.data != defaultChangedOption.preset.data) return true;
        return _presetDirty;
    }
    public void OnClickCancelButton()
    {
        if (PendingChanges())
        {
            PopupDialogScreen popupDialogScreen = Instantiate(confirmRevertPopupDialogScreen, transform.parent)
                .GetComponent<PopupDialogScreen>().Init("", "", new List<Menu.MenuItem>
                {
                    new(){text = "Yes", cb = () =>
                    {
                        Main.TheFrontEnd.PopScreen();
                        Destroy(gameObject);
                    }},
                    new(){text = "No", cb = () => Main.TheFrontEnd.PopScreen()}
                });
        }
        else Destroy(gameObject);
    }

    private string GetValueForOption(string option)
    {
        SettingOption find = _settingOptionList.Find(settingOption => settingOption.name == option);
        if (find == null) return null;

        if (_nowChangedOption.optionList.TryGetValue(find.name, out string changedValue)) return changedValue;

        if (((Dictionary<string, string>)_nowChangedOption.preset.otherInfoDictionary["overrides"])
            .TryGetValue(find.name, out string overrideValue))
        {
            return overrideValue;
        }

        return find.defaultValue;
    }
    private bool VerifyValidSeasonSettings()
    {
        if (world == DLCSupport.PORKLAND_DLC)
        {
            string temperate = GetValueForOption("temperate_season");
            string humid = GetValueForOption("humid_season");
            string lush = GetValueForOption("lush_season");
            
            if (temperate == "no_season" && lush == "no_season" && humid == "no_season") return false;
        }
        else if (world == DLCSupport.PORKLAND_DLC)
        {
            string mild = GetValueForOption("mild_season");
            string wet = GetValueForOption("wet_season");
            string green = GetValueForOption("green_season");
            string dry = GetValueForOption("dry_season");
            
            if (mild == "no_season" && wet == "no_season" && green == "no_season" && dry == "no_season")
                return false;
        }
        else
        {
            string autumn = GetValueForOption("autumn");
            string winter = GetValueForOption("winter");
            string spring = GetValueForOption("spring");
            string summer = GetValueForOption("summer");
            
            if (autumn == "no_season" && winter == "no_season" && spring == "no_season" && summer == "no_season")
                return false;
        }

        return true;
    }
    private bool VerifyValidSeasonStartSetting()
    {
        string seasonStart = GetValueForOption("season_start");
        string seasonLength = GetValueForOption(seasonStart);

        if (seasonLength == "no_season") return false;
        else return true;
    }
    public void Apply()
    {
        if (!VerifyValidSeasonSettings())
        {
            Instantiate(invalidOptionPopupDialogScreen, transform.parent)
                .GetComponent<PopupDialogScreen>().Init("All Seasons Disabled",
                    "You have set all of the seasons to the \"None\" option.\n" +
                    "Turn on at least one season to continue.\nDid you really expect that to work?",
                    new List<Menu.MenuItem>());
            return;
        }
        if (!VerifyValidSeasonStartSetting())
        {
            Instantiate(invalidOptionPopupDialogScreen, transform.parent)
                .GetComponent<PopupDialogScreen>().Init("Started Season Disabled",
                    "You have set the started seasons to the \"no_season\" option.\n" +
                    "Change the started season to another option for continuing.\n" +
                    "Did you really expect that to work?", new List<Menu.MenuItem>());
            return;
        }
        
        saveHandler(_nowChangedOption);
        Destroy(gameObject);
    }

    public void SavePreset()
    {
        int existedCustomPresetNum = _customPresetList.Count;
        
        if (existedCustomPresetNum > maxCustomPresetNum){}
        else
        {
            string basePresetId = (presetSpinner.GetSelectedIndex() < _defaultPresetNum
                    ? presetSpinner.GetSelectedData()
                    : presetSpinner.GetSelected().otherInfoDictionary["base_preset_id"]) as string;

            string presetId = $"custom_preset_{existedCustomPresetNum}";

            string[] dlcNameArray = { "DS", "ROG", "SW", "HAM" };
            string worldName = world < dlcNameArray.Length ? dlcNameArray[world] : "???";
            string presetName = $"Custom Preset {existedCustomPresetNum} ({worldName})";

            string presetDescription = $"Custom preset {existedCustomPresetNum}. Your world, your rules!";

            Dictionary<object,object> dictionary = new();
            foreach ((string key, string value) in _nowChangedOption.optionList) dictionary.Add(key, value);
            Level preset = new(){id = presetId, name = presetName, desc = presetDescription, overrides = dictionary};
            GameLogic.Profile.AddWorldCustomizationPreset(world, preset, existedCustomPresetNum);
            GameLogic.Profile.Save(null);

            SpinnerOption presetSpinnerOption = new SpinnerOption(presetName, presetId,
                new Dictionary<string, object> {
                    {"description", presetDescription},
                    {"overrides", _nowChangedOption.optionList},
                    {"base_preset_id", basePresetId}
                }
            );
            _presetList.Add(presetSpinnerOption);
            presetSpinner.SetOptions(_presetList);
            presetSpinner.SetSelected(presetId);
        }
    }
}