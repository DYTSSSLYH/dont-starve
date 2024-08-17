using System;
using System.Collections.Generic;
using System.Reflection;
using DYT;
using DYT.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MorgueScreen : MonoBehaviour
{
    public Image background;
    
    public Transform obitsRows;
    public int optionsPerScreen;
    public Button leftButton;
    public Button rightButton;
    
    
    private int _optionOffset = 0;
    private List<Morgue.Data> _morgueDataList;


    private void Reset()
    {
        background = GetComponent<Image>();
        obitsRows = transform.Find("Root").Find("ObitsPanel").Find("ObitsRows");
        optionsPerScreen = obitsRows.childCount;
        leftButton = transform.Find("Root").Find("ObitsPanel").Find("LeftButton").GetComponent<Button>();
        rightButton = transform.Find("Root").Find("ObitsPanel").Find("RightButton").GetComponent<Button>();
    }
    
    private void RefreshOptions()
    {
        for (int i = 0; i < optionsPerScreen; i++)
        {
            int index = i + _optionOffset;
            Transform group = obitsRows.GetChild(i);
            if (index >= _morgueDataList.Count)
            {
                group.gameObject.SetActive(false);
                continue;
            }
            
            
            group.gameObject.SetActive(true);
            
            Morgue.Data morgueData = _morgueDataList[index];

            TextMeshProUGUI daysLived = group.Find("DaysLived").GetComponent<TextMeshProUGUI>();
            daysLived.text = morgueData.daysSurvived <= 0 ? "?" : morgueData.daysSurvived.ToString();

            string character = morgueData.character;
            string path = "Images/SaveSlotPortraits";
            if (Constant.MOD_CHARACTER_LIST.Contains(character)) path += "/" + character;
            if (!DLCSupport.GetActiveCharacterList().Contains(character)) character = "random";
            Image portrait = group.Find("Deceased").Find("Portrait").GetComponent<Image>();
            portrait.sprite = ResourcesTool.LoadSprite(path, character);
            
            TextMeshProUGUI cause = group.Find("Cause").GetComponent<TextMeshProUGUI>();
            string killedBy = morgueData.killedBy;
            if (killedBy == null) killedBy = character == "maxwell" ? "charlie" : "darkness";
            else if (killedBy == "unknown") killedBy = "shenanigans";
            else if (killedBy == "moose") killedBy = Random.Range(0, 1) < 0.5 ? "moose1" : "moose2";
            Debug.Log("killed_by: " + killedBy);
            killedBy = killedBy.ToUpper();
            Type type = typeof(Strings.NAMES);
            FieldInfo fieldInfo = type.GetField(killedBy);
            killedBy = (string)(fieldInfo != null ? fieldInfo.GetValue(null) : type.GetField("SHENANIGANS"));
            cause.text = killedBy;
            
            TextMeshProUGUI mode = group.Find("Mode").GetComponent<TextMeshProUGUI>();
            mode.text = Strings.UI.MorgueScreen.LEVEL_TYPE[(int)Levels.GetTypeForLevelID(morgueData.world)];
        }
    }
    private void Scroll(int dir)
    {
        _optionOffset += dir;
        
        RefreshOptions();

        
        leftButton.interactable = true;
        rightButton.interactable = true;

        if (_optionOffset - optionsPerScreen < 0) leftButton.interactable = false;
        if (_optionOffset + optionsPerScreen >= _morgueDataList.Count) rightButton.interactable = false;
    }
    private void Start()
    {
        DLCSupport.SetBGcolor(background, false);
        
        _morgueDataList = Morgue.persistData;
        
        leftButton.onClick.AddListener(() => Scroll(-optionsPerScreen));
        rightButton.onClick.AddListener(() => Scroll(optionsPerScreen));
        
        Scroll(0);
    }


    public void Ok()
    {
        Destroy(gameObject);
    }
}