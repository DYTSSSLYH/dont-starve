using System.Collections.Generic;
using DYT;
using DYT.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class NewGameScreen : MonoBehaviour
    {
        public int saveSlot;

        public Image portrait;
        public ToggleGroup toggleGroup;
    
        public GameObject rogWarningBigPopupDialogScreen;
        public GameObject characterSelectScreen;
        public GameObject customScreen;


        private int xpThresholdFInRogDifficultyWarning = 20 * 32;
        private string character;
        private CustomScreen.ChangedOption[] _savedCustomOptionArray = new CustomScreen.ChangedOption[4];


        private void Reset()
        {
            portrait = transform.Find("Portrait").GetComponent<Image>();
            toggleGroup = transform.Find("Menu").Find("DLCButtons").GetComponent<ToggleGroup>();
        }

        private void Start()
        {
            Debug.Log($"Loading slot {saveSlot} for new game");
        }


        public int GetEnabledWorldIndex()
        {
            return toggleGroup.GetFirstActiveToggle().transform.GetSiblingIndex();
        }

        public DLCSupport.DLCTable GetEnabledDLCs()
        {
            DLCSupport.DLCTable dlc = new()
            {
                REIGN_OF_GIANTS = DLCSupport.IsDLCEnabled(DLCSupport.REIGN_OF_GIANTS),
                CAPY_DLC = DLCSupport.IsDLCEnabled(DLCSupport.CAPY_DLC),
                PORKLAND_DLC = DLCSupport.IsDLCEnabled(DLCSupport.PORKLAND_DLC)
            };
            return dlc;
        }
        
        private CustomScreen.ChangedOption GetSavedCustomOptions()
        {
            return _savedCustomOptionArray[GetEnabledWorldIndex()];
        }
        private void OnSaved()
        {
            MainFunctions.StartNextInstance(new MainFunctions.Setting
            {
                reset_action = Constant.RESET_ACTION.LOAD_SLOT, save_slot = saveSlot
            });
        }
        private void StartGame(string worldName)
        {
            int enabledDlc = DLCSupport.IsDLCEnabled(DLCSupport.PORKLAND_DLC) ? DLCSupport.PORKLAND_DLC :
                DLCSupport.IsDLCEnabled(DLCSupport.CAPY_DLC) ? DLCSupport.CAPY_DLC :
                DLCSupport.IsDLCEnabled(DLCSupport.REIGN_OF_GIANTS) ? DLCSupport.REIGN_OF_GIANTS :
                DLCSupport.MAIN_GAME;
        
            GameLogic.SaveGameIndex.StartSurvivalMode(
                saveSlot, character, GetSavedCustomOptions(), OnSaved, GetEnabledDLCs(), worldName);
        }
        public void OnClickStartButton()
        {
            int xp = GameLogic.Profile.persistData.xp;

            if (xp < xpThresholdFInRogDifficultyWarning)
            {
                Instantiate(rogWarningBigPopupDialogScreen, transform.parent);
                return;
            }

            int enabledWorldIndex = GetEnabledWorldIndex();
            StartGame(enabledWorldIndex == DLCSupport.PORKLAND_DLC ? "hamlet" :
                enabledWorldIndex == DLCSupport.CAPY_DLC ? "shipwrecked" : "survival");
        }

        public void ChangeCharacter()
        {
            CharacterSelectScreen instantiate =
                Instantiate(characterSelectScreen, transform.parent).GetComponent<CharacterSelectScreen>();

            instantiate.defaultCharacter = character;
        
            instantiate.applyHandler = character =>
            {
                if (character == "random")
                {
                    List<string> allCharacter = GameLogic.Profile.GetUnlockedCharacters();
                    character = allCharacter[Random.Range(0, allCharacter.Count)];
                }
            
                this.character = character;

            
                string path = Constant.MOD_CHARACTER_LIST.Contains(character)
                    ? $"Images/SaveSlotPortraits/{character}"
                    : "Images/SaveSlotPortraits";

                portrait.sprite = ResourcesTool.LoadSprite(path, character);
            };
        }
    
        public void OnClickWorldButton()
        {
            CustomScreen instantiate = Instantiate(customScreen, transform.root).GetComponent<CustomScreen>();
            instantiate.world = GetEnabledWorldIndex();
            instantiate.saveHandler = changedOption => _savedCustomOptionArray[instantiate.world] = changedOption;
            Debug.Log($"GETTING CUSTOM OPTIONS FOR {instantiate.world}");
            instantiate.defaultChangedOption = GetSavedCustomOptions();
        }
    
        public void OnClickCancelButton()
        {
            Destroy(gameObject);
        }
    }
}