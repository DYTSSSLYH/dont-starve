using System.Collections.Generic;
using DYT;
using DYT.Tools;
using Screens;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameScreen : MonoBehaviour
{
    public Transform menu;
    public GameObject saveTilePrefab;
    public AudioClip audioClip;
    public GameObject newGameScreenPrefab;
    
    public int displayRows = 5;
    public int optionOffset = 0;
    public Button leftButton;
    public Button rightButton;
    
    public Button cancelButton;
    public Button morgueButton;
    public GameObject morgueScreen;


    private void OnClickTile(int slotNum)
    {
        Main.TheFrontEnd.GetSound().PlayOneShot(audioClip);

        if (GameLogic.SaveGameIndex.GetCurrentMode(slotNum) == null)
        {
            GameObject newGameScreen = Instantiate(newGameScreenPrefab, transform.parent);
            NewGameScreen newGameScreenComponent = newGameScreen.GetComponent<NewGameScreen>();
            newGameScreenComponent.saveSlot = slotNum;
        }
        else
        {
            
        }
    }
    private void MakeSaveTile(int slotNum)
    {
        string mode = GameLogic.SaveGameIndex.GetCurrentMode(slotNum);
        string character = GameLogic.SaveGameIndex.GetSlotCharacter(slotNum);
        DLCSupport.DLCTable dlcDictionary = GameLogic.SaveGameIndex.GetSlotDLC(slotNum);
        bool rog = dlcDictionary.REIGN_OF_GIANTS;
        bool capyDLC = dlcDictionary.CAPY_DLC;
        bool porkDLC = dlcDictionary.PORKLAND_DLC;
        int world = GameLogic.SaveGameIndex.GetSlotWorld(slotNum);
        int day = GameLogic.SaveGameIndex.GetSlotDay(slotNum);
        
        Transform saveTile = Instantiate(saveTilePrefab, menu).transform;
        Transform baseTransform = saveTile.Find("Base");
        
        GameObject portraitBackground = baseTransform.Find("PortraitBackground").gameObject;
        Image portrait = baseTransform.Find("Portrait").GetComponent<Image>();
        if (character != null && mode != null)
        {
            string path = Constant.MOD_CHARACTER_LIST.Contains(character)
                ? "Images/SaveSlotPortraits/" + character
                : "Images/SaveSlotPortraits";
            portrait.sprite = ResourcesTool.LoadSprite(path, character);
        }
        else portraitBackground.SetActive(false);

        Image dlcIndicator = baseTransform.Find("DlcIndicator").GetComponent<Image>();
        if (character != null && mode != null)
        {
            Sprite sprite;
            if (porkDLC) sprite = ResourcesTool.LoadSprite("Images/ui", "HAMicon");
            else if (rog) sprite = ResourcesTool.LoadSprite("Images/ui", "DLCicon");
            else if (capyDLC) sprite = ResourcesTool.LoadSprite("Images/ui", "SWicon");
            else sprite = ResourcesTool.LoadSprite("Images/ui", "DSicon");
            dlcIndicator.sprite = sprite;
        }

        TextMeshProUGUI text = baseTransform.Find("Text").GetComponent<TextMeshProUGUI>();
        if (mode == null)
        {
            text.text = "New Game";
            RectTransform textRectTransform = (RectTransform)(text.transform);
            textRectTransform.anchoredPosition = new Vector2(0, 0);
        }
        else if (mode == "adventure") text.text = $"Adventure {world}-{day}";
        else if (mode == "survival") text.text = $"Survival {world}-{day}";
        else if (mode == "cave") text.text = $"Cave Depth {GameLogic.SaveGameIndex.GetCurrentCaveLevel(slotNum, 0)}";
        else if (mode == "shipwrecked") text.text = $"Shipwrecked {world}-{day}";
        else if (mode == "volcano") text.text = $"Volcano {world}-{day}";
        else if (mode == "porkland") text.text = $"Hamlet {world}-{day}";
        else text.text = "Modded";

        saveTile.GetComponent<SaveTile>().onClickTile += () => OnClickTile(slotNum);
    }
    private void RefreshFiles()
    {
        for (int i = 0; i < menu.childCount; i++) Destroy(menu.GetChild(i).gameObject);

        int totalPage = Mathf.Min(optionOffset + displayRows, Constant.NUM_SAVE_SLOTS);
        for (int i = optionOffset; i < totalPage; i++) MakeSaveTile(i);
    }
    public void Scroll(int dir)
    {
        optionOffset += dir;
        
        RefreshFiles();
        
        leftButton.interactable = true;
        rightButton.interactable = true;
        if (optionOffset < displayRows) leftButton.interactable = false;
        if (optionOffset + displayRows >= Constant.NUM_SAVE_SLOTS) rightButton.interactable = false;
    }
    
    
    // Start is called before the first frame update
    private void Start()
    {
        cancelButton.onClick.AddListener(() => Destroy(gameObject));
        morgueButton.onClick.AddListener(() => Instantiate(morgueScreen, transform.parent));
        
        Scroll(0);
    }
}