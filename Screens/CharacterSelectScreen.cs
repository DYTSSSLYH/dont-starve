using System;
using System.Collections.Generic;
using DYT;
using DYT.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectScreen : MonoBehaviour
{
    public string defaultCharacter { get; set; }
    public Action<string> applyHandler { get; set; }


    public Image background;
    
    public Button leftButton;
    public Transform secondCharacterPortrait;
    public Button rightButton;
    
    public Image heroPortrait;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterQuote;
    public TextMeshProUGUI characterDetails;
    
    public Button applyButton;
    
    
    public Transform firstCharacterPortrait;
    public Transform thirdCharacterPortrait;
    
    
    private static readonly int Selected = Animator.StringToHash("Selected");
    
    private int offset { get; set; }
    private string nowCharacter { get; set; }
    private List<string> characterList { get; set; }
    private List<Image> portraitList { get; set; }


    private void Reset()
    {
        background = GetComponent<Image>();
        
        Transform fixedRoot = transform.Find("FixedRoot");
        
        heroPortrait = fixedRoot.Find("HeroPortrait").GetComponent<Image>();
        characterName = fixedRoot.Find("CharacterName").GetComponent<TextMeshProUGUI>();
        characterQuote = fixedRoot.Find("CharacterQuote").GetComponent<TextMeshProUGUI>();
        characterDetails = fixedRoot.Find("CharacterDetails").GetComponent<TextMeshProUGUI>();
        secondCharacterPortrait = fixedRoot.Find("SecondCharacterPortrait");
        applyButton = fixedRoot.Find("ApplyButton").GetComponent<Button>();
        
        leftButton = fixedRoot.Find("LeftButton").GetComponent<Button>();
        rightButton = fixedRoot.Find("RightButton").GetComponent<Button>();
        firstCharacterPortrait = fixedRoot.Find("FirstCharacterPortrait");
        thirdCharacterPortrait = fixedRoot.Find("ThirdCharacterPortrait");
    }
    private void Start()
    {
        portraitList = new List<Image>
        {
            firstCharacterPortrait.Find("Portrait").GetComponent<Image>(),
            secondCharacterPortrait.Find("Portrait").GetComponent<Image>(),
            thirdCharacterPortrait.Find("Portrait").GetComponent<Image>()
        };

        DLCSupport.SetBGcolor(background, false);

        characterList = DLCSupport.GetActiveCharacterListForSelection();
        
        secondCharacterPortrait.Find("Background").GetComponent<Animator>().SetBool(Selected, true);


        for (int i = 0; i < characterList.Count; i++)
        {
            if (characterList[i] == defaultCharacter) offset = i;
        }

        Scroll(0);
    }


    public void Scroll(int scroll)
    {
        offset += scroll;

        
        string basePath = "Images/SelectScreenPortraits";
        string character = characterList[offset];
        nowCharacter = character;

        
        if (GameLogic.Profile.IsCharacterUnlocked(character))
        {
            heroPortrait.sprite = ResourcesTool.LoadSprite($"BigPortraits/{character}", character);
            characterName.text = Strings.CHARACTER_TITLES.GetValueOrDefault(character, "");
            characterQuote.text = Strings.CHARACTER_QUOTES.GetValueOrDefault(character, "");
            characterDetails.text = Strings.CHARACTER_DESCRIPTIONS.GetValueOrDefault(character, "");
            applyButton.interactable = true;
        }
        else
        {
            heroPortrait.sprite = ResourcesTool.LoadSprite("BigPortraits/locked", "locked");
            characterName.text = "The Unknown";
            characterQuote.text = "";
            characterDetails.text = "";
            applyButton.interactable = false;
        }
        
        string path = basePath;
        portraitList[1].sprite = ResourcesTool.LoadSprite(path,
            GameLogic.Profile.IsCharacterUnlocked(character) ? character : character + "_silho");

        
        leftButton.interactable = true;
        firstCharacterPortrait.gameObject.SetActive(true);
        rightButton.interactable = true;
        thirdCharacterPortrait.gameObject.SetActive(true);

        if (offset - 1 < 0)
        {
            leftButton.interactable = false;
            firstCharacterPortrait.gameObject.SetActive(false);
        }
        else
        {
            character = characterList[offset - 1];
            path = Constant.MOD_CHARACTER_LIST.Contains(character) ? basePath + "/" + character : basePath;
            portraitList[0].sprite = ResourcesTool.LoadSprite(path,
                GameLogic.Profile.IsCharacterUnlocked(character) ? character : character + "_silho");
        }

        if (offset + 1 > characterList.Count - 1)
        {
            rightButton.interactable = false;
            thirdCharacterPortrait.gameObject.SetActive(false);
        }
        else
        {
            character = characterList[offset + 1];
            path = Constant.MOD_CHARACTER_LIST.Contains(character) ? basePath + "/" + character : basePath;
            portraitList[2].sprite = ResourcesTool.LoadSprite(path,
                GameLogic.Profile.IsCharacterUnlocked(character) ? character : character + "_silho");
        }
    }

    public void Apply()
    {
        if (applyHandler != null) applyHandler(nowCharacter);
        
        Destroy(gameObject);
    }
    public void Random()
    {
        if (applyHandler != null) applyHandler("random");
        
        Destroy(gameObject);
    }
    public void Cancel()
    {
        Destroy(gameObject);
    }
}