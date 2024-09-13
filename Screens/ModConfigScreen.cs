using System.Collections.Generic;
using DYT;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModConfigScreen : MonoBehaviour
{
    public string modName;
    
    public int columnCount = 2;
    public int rowCountPerColumn = 7;
    public int optionOffset;
    public GameObject optionPrefab;
    
    public GameObject confirmScreenPrefab;

    
    private Button _leftButton;
    private Button _rightButton;
    private List<KnownModIndex.Config> _configOptionList;
    private int _elementCountPerScreen;
    private Transform _main;


    public void Apply()
    {
        KnownModIndex.SaveConfigurationOptions(()=>{}, modName, _configOptionList);
        foreach (KnownModIndex.Config configOption in _configOptionList)
            configOption.savedIndex = configOption.currentIndex;
        Destroy(gameObject);
    }
    private void Cancel()
    {
        GameObject confirmScreen = Instantiate(confirmScreenPrefab, transform.parent);
        confirmScreen.transform.Find("Yes").GetComponent<Button>().onClick.AddListener(() => {
            Destroy(confirmScreen);
            Destroy(gameObject);
        });
    }
    private void ResetToDefaultValues()
    {
        GameObject confirmScreen = Instantiate(confirmScreenPrefab, transform.parent);
        confirmScreen.transform.Find("Yes").GetComponent<Button>().onClick.AddListener(() => {
            
            foreach (KnownModIndex.Config configOption in _configOptionList)
                configOption.currentIndex = configOption.defaultIndex;
        
            Scroll(0);
            
            Destroy(confirmScreen);
        });
    }
    
    private void RefreshOptions()
    {
        for (int i = 0; i < _main.childCount; i++) Destroy(_main.GetChild(i).gameObject);
        
        int end = Mathf.Min(optionOffset + _elementCountPerScreen, _configOptionList.Count);
        for (int i = optionOffset; i < end; i++)
        {
            GameObject option = Instantiate(optionPrefab, _main);
            Spinner spinner = option.GetComponent<Spinner>();
            List<SpinnerOption> spinnerOptionList = new List<SpinnerOption>();
            for (int j = 0; j < _configOptionList[i].optionList.Count; j++)
            {
                KnownModIndex.Option configOption = _configOptionList[i].optionList[j];
                spinnerOptionList.Add(new SpinnerOption(configOption.description, j));
            }
            spinner.SetOptions(spinnerOptionList);
            int index = _configOptionList[i].currentIndex != -1
                ? _configOptionList[i].currentIndex
                : _configOptionList[i].defaultIndex;
            spinner.onChanged += (_, data) => _configOptionList[i].currentIndex = (int)data;
            spinner.SetSelectedIndex(index);

            TextMeshProUGUI label = option.transform.Find("Label").GetComponent<TextMeshProUGUI>();
            if (_configOptionList[i].label != null) label.text = _configOptionList[i].label;
            else if (_configOptionList[i].name != null) label.text = _configOptionList[i].name;
        }
    }
    private void Scroll(int dir)
    {
        optionOffset += dir;
        
        RefreshOptions();

        if (!_leftButton.interactable && optionOffset >= _elementCountPerScreen) _leftButton.interactable = true;
        else if (_leftButton.interactable && optionOffset < _elementCountPerScreen)
            _leftButton.interactable = false;

        if (!_rightButton.interactable && optionOffset + _elementCountPerScreen < _configOptionList.Count)
            _rightButton.interactable = true;
        else if (_rightButton.interactable && optionOffset + _elementCountPerScreen >= _configOptionList.Count)
            _rightButton.interactable = false;
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        DLCSupport.SetBGcolor(GetComponent<Image>(), false);

        string titleText = KnownModIndex.GetModFancyName(modName);
        int maxTitleLength = 26;
        if (titleText.Length > maxTitleLength) titleText = titleText.Substring(0, maxTitleLength);
        titleText += " Configuration Options";
        transform.Find("Title").GetComponent<TextMeshProUGUI>().text = titleText;

        Transform menu = transform.Find("Menu");
        Button cancelButton = menu.Find("CancelButton").GetComponent<Button>();
        cancelButton.onClick.AddListener(Cancel);
        Button resetToDefaultButton = menu.Find("ResetToDefaultButton").GetComponent<Button>();
        resetToDefaultButton.onClick.AddListener(ResetToDefaultValues);

        Transform optionsPanel = transform.Find("OptionsPanel");
        _leftButton = optionsPanel.Find("LeftButton").GetComponent<Button>();
        _leftButton.onClick.AddListener(() => Scroll(-_elementCountPerScreen));
        _rightButton = optionsPanel.Find("RightButton").GetComponent<Button>();
        _rightButton.onClick.AddListener(() => Scroll(_elementCountPerScreen));
        _main = optionsPanel.Find("Main");
        
        _configOptionList = KnownModIndex.LoadModConfigurationOptions(modName);
        foreach (KnownModIndex.Config configOption in _configOptionList)
            configOption.currentIndex =
                configOption.savedIndex != -1 ? configOption.savedIndex : configOption.defaultIndex;
        
        _elementCountPerScreen = columnCount * rowCountPerColumn;
        optionOffset = 0;
        Scroll(0);
    }
}