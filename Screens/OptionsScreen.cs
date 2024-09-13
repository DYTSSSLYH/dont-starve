using System;
using System.Collections.Generic;
using DYT;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScreen : MonoBehaviour
{
    public RectTransform menu;
    public GameObject changedMenu;
    public GameObject acceptGraphicPopupDialogScreen;
    public GameObject acceptPopupDialogScreen;
    public GameObject unChangedMenu;

    public TextMeshProUGUI dlcOptionsTitle;
    
    public Spinner smallTexturesSpinner;
    public Spinner netbookModeSpinner;
    public Spinner dynamicLoadingLevelSpinner;
    public GameObject restartDynamicLoadingLevelPrefab;
    public GameObject performanceGrid;

    public GameObject hamletGridPrefab;

    #region grid 相关属性
    
    public Transform grid;
    
    public Spinner bloomSpinner;
    public Spinner distortionSpinner;
    public Spinner screenShakeSpinner;
    public Spinner fullScreenSpinner;
    public Spinner displaySpinner;
    public Spinner resolutionSpinner;
    public Spinner refreshRateSpinner;
    public Spinner wathgrithrFontSpinner;
    
    public NumericSpinner fxVolumeSpinner;
    public NumericSpinner musicVolumeSpinner;
    public NumericSpinner ambientVolumeSpinner;
    public NumericSpinner hudSizeSpinner;
    public Spinner screenFlashSpinner;
    public Spinner vibrationSpinner;
    public Spinner integratedBackpackSpinner;
    public Spinner sendStatsSpinner;
    public GameObject dataCollectionBiggerPopupDialogScreen;

    #endregion
    
    public Button leftButton;
    public Button rightButton;
    
    
    private Spinner renderJungleCanopySpinner;
    private Spinner renderJungleVinesSpinner;
    
    private List<SpinnerOption> enableDisableOptionList = new List<SpinnerOption>
    {
        new SpinnerOption("Disabled", false),
        new SpinnerOption("Enabled", true)
    };
    private List<SpinnerOption> enableScreenFlashOptionList = new List<SpinnerOption>
    {
        new SpinnerOption("Default", 1),
        new SpinnerOption("Dim", 2),
        new SpinnerOption("Dimmest", 3)
    };
    private List<SpinnerOption> integratedBackpackOptionList = new List<SpinnerOption>
    {
        new SpinnerOption("Separated", false),
        new SpinnerOption("Integrated", true)
    };

    private class Options : ICloneable
    {
        public bool smallTextures = false;
        public bool netbookMode = false;
        public int dynamicLoadingLevel = 0;
        public bool hamlet_render_jungle_canopy = PlayerProfile.GetDLCSetting("hamlet", "render-jungle-canopy");
        public bool hamlet_render_jungle_vines = PlayerProfile.GetDLCSetting("hamlet", "render-jungle-vines");
        
        
        public bool bloom = PlayerProfile.GetBloomEnabled();
        public bool distortion = PlayerProfile.GetDistortionEnabled();
        public bool screenShake = PlayerProfile.IsScreenShakeEnabled();
        public bool fullScreen = false;
        public int display = 0;
        public int modeIndex = 0;
        public int refreshRate = 90;
        public bool wathgrithrFont = PlayerProfile.IsWathgrithrFontEnabled();
        
        public int fxVolume = (int)Mathf.Round(TheMixer.GetLevel("set_sfx") * 10);
        public int musicVolume = (int)Mathf.Round(TheMixer.GetLevel("set_music") * 10);
        public int ambientVolume = (int)Mathf.Round(TheMixer.GetLevel("set_ambience") * 10);
        public int hudSize = PlayerProfile.GetHUDSize();
        public int screenFlash = PlayerProfile.GetScreenFlash();
        public bool vibration = PlayerProfile.GetVibrationEnabled();
        public bool integratedBackpack = PlayerProfile.GetIntegratedBackpack();
        public bool sendStats = PlayerProfile.GetAgreementsSetting();

        
        public object Clone()
        {
            return new Options()
            {
                smallTextures = smallTextures,
                netbookMode = netbookMode,
                dynamicLoadingLevel = dynamicLoadingLevel,
                hamlet_render_jungle_canopy = hamlet_render_jungle_canopy,
                hamlet_render_jungle_vines = hamlet_render_jungle_vines,
                
                bloom = bloom,
                distortion = distortion,
                screenShake = screenShake,
                fullScreen = fullScreen,
                display = display,
                modeIndex = modeIndex,
                refreshRate = refreshRate,
                wathgrithrFont = wathgrithrFont,
                    
                fxVolume = fxVolume,
                musicVolume = musicVolume,
                ambientVolume = ambientVolume,
                hudSize = hudSize,
                screenFlash = screenFlash,
                vibration = vibration,
                integratedBackpack = integratedBackpack,
                sendStats = sendStats
            };
        }

        public bool Equals(Options other)
        {
            return smallTextures == other.smallTextures &&
                   netbookMode == other.netbookMode &&
                   dynamicLoadingLevel == other.dynamicLoadingLevel &&
                   hamlet_render_jungle_canopy == other.hamlet_render_jungle_canopy &&
                   hamlet_render_jungle_vines == other.hamlet_render_jungle_vines &&
                   bloom == other.bloom && distortion == other.distortion &&
                   screenShake == other.screenShake && fullScreen == other.fullScreen &&
                   display == other.display && modeIndex == other.modeIndex &&
                   refreshRate == other.refreshRate && wathgrithrFont == other.wathgrithrFont &&
                   fxVolume == other.fxVolume && musicVolume == other.musicVolume &&
                   ambientVolume == other.ambientVolume && hudSize == other.hudSize &&
                   screenFlash == other.screenFlash && vibration == other.vibration &&
                   integratedBackpack == other.integratedBackpack && sendStats == other.sendStats;
        }
    }
    private Options _options;
    private Options _working;
    
    private class Grid
    {
        public GameObject grid;
        public string title;

        public Grid(GameObject grid, string title)
        {
            this.grid = grid;
            this.title = title;
        }
    }
    private List<Grid> _gridList = new List<Grid>();

    private bool _shownDynamicLoadingLevelWarning = false;

    private int _activePage = 1;


    private void Reset()
    {
        menu = transform.Find("Menu") as RectTransform;
        
        Transform shield = transform.Find("Shield");
        leftButton = shield.Find("LeftButton").GetComponent<Button>();
        rightButton = shield.Find("RightButton").GetComponent<Button>();
        
        grid = transform.Find("Grid");
        wathgrithrFontSpinner =
            grid.Find("WathgrithrFontSpinnerGroup").Find("WathgrithrFontSpinner").GetComponent<Spinner>();
    }


    private bool Changed()
    {
        return !_working.Equals(_options);
    }
    private void Save(Action callback)
    {
        _options = (Options)_working.Clone();
        
        PlayerProfile.SetVolume(_options.ambientVolume, _options.fxVolume, _options.musicVolume);
        PlayerProfile.SetBloomEnabled(_options.bloom);
        PlayerProfile.SetDistortionEnabled(_options.distortion);
        PlayerProfile.SetScreenShakeEnabled(_options.screenShake);
        
        PlayerProfile.SetWathgrithrFontEnabled(_options.wathgrithrFont);
        PlayerProfile.SetHUDSize(_options.hudSize);
        
        PlayerProfile.SetScreenFlash(_options.screenFlash);
        
        PlayerProfile.SetIntegratedBackpack(_options.integratedBackpack);
        
        PlayerProfile.SetVibrationEnabled(_options.vibration);
        PlayerProfile.SetAgreementsSetting(_options.sendStats);
        
        PlayerProfile.SetDLCSetting("hamlet", "render-jungle-canopy", _options.hamlet_render_jungle_canopy);
        PlayerProfile.SetDLCSetting("hamlet", "render-jungle-vines", _options.hamlet_render_jungle_vines);
        
        GameLogic.Profile.Save(_ =>
        {
            if (callback != null) callback();
        });
    }
    private bool IsGraphicsDirty()
    {
        if (_working.fullScreen != _options.fullScreen) return true;

        if (_working.fullScreen)
        {
            bool dirty = _working.display != _options.display || _working.modeIndex != _options.modeIndex ||
                         _working.refreshRate != _options.refreshRate;

            return dirty;
        }

        return false;
    }
    private void ApplyChanges()
    {
        if (IsGraphicsDirty())
        {
            Transform instantiate = Instantiate(acceptGraphicPopupDialogScreen, transform.root).transform;
            instantiate.Find("Menu").Find("AcceptButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                Apply();
                Save(() =>
                {
                    UpdateMenu();
                    Destroy(instantiate.gameObject);
                });
            });
            instantiate.Find("Menu").Find("CancelButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                RevertChanges();
                Destroy(instantiate.gameObject);
            });
        }
        else
        {
            Transform instantiate = Instantiate(acceptPopupDialogScreen, transform.root).transform;
            instantiate.Find("Menu").Find("AcceptButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                Apply();
                Save(() =>
                {
                    Destroy(instantiate.gameObject);
                    Destroy(gameObject);
                });
            });
        }
    }
    private void Apply()
    {
        ApplyVolume();
        
        PlayerProfile.SetScreenShakeEnabled(_working.screenShake);
        PlayerProfile.SetAgreementsSetting(_working.sendStats);
        PlayerProfile.SetWathgrithrFontEnabled(_working.wathgrithrFont);
        TheSim.SetSetting("graphics", "dynamic-loading-level", _working.dynamicLoadingLevel.ToString());
        
        PlayerProfile.SetIntegratedBackpack(_working.integratedBackpack);
    }
    private void RevertChanges()
    {
        _working = (Options)_options.Clone();
        Apply();
        InitializeSpinners();
        UpdateMenu();
    }
    private void UpdateMenu()
    {
        for (int i = 0; i < menu.childCount; i++) Destroy(menu.GetChild(i).gameObject);

        if (Changed())
        {
            Transform instantiate = Instantiate(changedMenu, menu).transform;
            instantiate.Find("ApplyButton").GetComponent<Button>().onClick.AddListener(ApplyChanges);
            instantiate.Find("RevertChangesButton").GetComponent<Button>().onClick.AddListener(RevertChanges);
        }
        else
        {
            Transform instantiate = Instantiate(unChangedMenu, menu).transform;
            Button closeButton = instantiate.Find("CloseButton").GetComponent<Button>();
            closeButton.onClick.AddListener(() => Destroy(gameObject));
        }
    }
    private void DoInitPerformancePage()
    {
        smallTexturesSpinner.SetOptions(enableDisableOptionList);
        smallTexturesSpinner.onChanged += (_, data) =>
        {
            _working.smallTextures = (bool)data;
            UpdateMenu();
        };
        
        netbookModeSpinner.SetOptions(enableDisableOptionList);
        netbookModeSpinner.onChanged += (_, data) =>
        {
            _working.netbookMode = (bool)data;
            UpdateMenu();
        };

        dynamicLoadingLevelSpinner.SetOptions(new List<SpinnerOption>
        {
            new SpinnerOption("Disabled", 0),
            new SpinnerOption("Some", 1),
            new SpinnerOption("All", 2)
        });
        dynamicLoadingLevelSpinner.onChanged += (spinner, data) =>
        {
            if (!_shownDynamicLoadingLevelWarning)
            {
                Transform restartDynamicLoadingLevel =
                    Instantiate(restartDynamicLoadingLevelPrefab, transform.root).transform;

                Transform restartDynamicLoadingLevelMenu = restartDynamicLoadingLevel.Find("Menu");
                restartDynamicLoadingLevelMenu.Find("OK").GetComponent<Button>().onClick.AddListener(() =>
                {
                    _shownDynamicLoadingLevelWarning = true;
                    _working.dynamicLoadingLevel = (int)data;
                    Destroy(restartDynamicLoadingLevel.gameObject);
                    UpdateMenu();
                });
                restartDynamicLoadingLevelMenu.Find("Cancel").GetComponent<Button>().onClick.AddListener(() =>
                {
                    dynamicLoadingLevelSpinner.SetSelectedIndex(_working.dynamicLoadingLevel);
                    Destroy(restartDynamicLoadingLevel.gameObject);
                    UpdateMenu();
                });
            }
            else
            {
                _working.dynamicLoadingLevel = (int)data;
                UpdateMenu();
            }
        };
        
        _gridList.Add(new Grid(performanceGrid, "Performance"));
    }
    private void DoInitHamletPage()
    {
        bool showHamletOptions = DLCSupport.IsDLCEnabled(DLCSupport.PORKLAND_DLC);
        if (!showHamletOptions) return;

        Transform hamletGrid = Instantiate(hamletGridPrefab, transform).transform;
        
        renderJungleCanopySpinner = hamletGrid.Find("RenderJungleCanopySpinnerGroup")
            .Find("RenderJungleCanopySpinner").GetComponent<Spinner>();
        renderJungleCanopySpinner.SetOptions(enableDisableOptionList);
        renderJungleCanopySpinner.onChanged += (_, data) =>
        {
            _working.hamlet_render_jungle_canopy = (bool)data;
            UpdateMenu();
        };
        
        renderJungleVinesSpinner = hamletGrid.Find("RenderJungleVinesSpinnerGroup")
            .Find("RenderJungleVinesSpinner").GetComponent<Spinner>();
        renderJungleVinesSpinner.SetOptions(enableDisableOptionList);
        renderJungleVinesSpinner.onChanged += (_, data) =>
        {
            _working.hamlet_render_jungle_vines = (bool)data;
            UpdateMenu();
        };
        
        _gridList.Add(new Grid(hamletGrid.gameObject, "Hamlet"));
    }
    private void UpdateResolutionsSpinner()
    {
        resolutionSpinner.SetOptions(GetDisplayModes(_working.display));

        if ((bool)(fullScreenSpinner.GetSelected().data))
        {
            displaySpinner.Enable();
            resolutionSpinner.Enable();
            refreshRateSpinner.Enable();

            int spinnerIndex = 0;
            if (_working.modeIndex != 0)
            {}
            resolutionSpinner.SetSelectedIndex(spinnerIndex);
        }
        else
        {
            displaySpinner.Disable();
            resolutionSpinner.Disable();
            refreshRateSpinner.Disable();
        }
    }
    private List<SpinnerOption> GetDisplays()
    {
        return new List<SpinnerOption>
        {
            new SpinnerOption(Screen.width + " × " + Screen.height, 0)
        };
    }
    private void UpdateRefreshRatesSpinner()
    {
        int currentRefreshRate = _working.refreshRate;

        List<SpinnerOption> refreshRateList = GetRefreshRates(_working.display, _working.modeIndex);
        refreshRateSpinner.SetOptions(refreshRateList);
        refreshRateSpinner.SetSelectedIndex(0);

        for (int i = 0; i < refreshRateList.Count; i++)
        {
            if ((int)(refreshRateList[i].data) == currentRefreshRate)
            {
                refreshRateSpinner.SetSelectedIndex(i);
                break;
            }
        }
    }
    private List<SpinnerOption> GetDisplayModes(int displayId)
    {
        List<SpinnerOption> spinnerOptions = new List<SpinnerOption>();
        spinnerOptions.Add(new SpinnerOption(Screen.width + " × " + Screen.height, 0));
        return spinnerOptions;
    }
    private List<SpinnerOption> GetRefreshRates(int displayId, int modeIndex)
    {
        return new List<SpinnerOption>
        {
            new SpinnerOption("60", 60),
            new SpinnerOption("90", 90)
        };
    }
    private void ApplyVolume()
    {
        TheMixer.SetLevel("set_sfx", _working.fxVolume / 10f);
        TheMixer.SetLevel("set_music", _working.musicVolume / 10f);
        TheMixer.SetLevel("set_ambience", _working.ambientVolume / 10f);
    }
    private void DataCollectionPopup()
    {
        GameObject instantiate = Instantiate(dataCollectionBiggerPopupDialogScreen, transform.root);
        Transform biggerPopupDialogScreenMenu = instantiate.transform.Find("Menu");
        biggerPopupDialogScreenMenu.Find("Close").GetComponent<Button>().onClick.AddListener(
            () => Destroy(instantiate)
        );
        biggerPopupDialogScreenMenu.Find("PrivacyCenter").GetComponent<Button>().onClick.AddListener(
            () => Main.VisitURL("https://www.klei.com/privacy-policy")
        );
    }
    private void DoInitMainPage()
    {
        grid.localScale = new Vector3(1, DLCSupport.IsDLCEnabled(DLCSupport.REIGN_OF_GIANTS) ? 0.9f : 0.95f, 1);
        
        UpdateMenu();

        #region 左列设置项
        
        bloomSpinner.SetOptions(enableDisableOptionList);
        bloomSpinner.onChanged += (_, data) =>
        {
            _working.bloom = (bool)data;
            UpdateMenu();
        };

        distortionSpinner.SetOptions(enableDisableOptionList);
        distortionSpinner.onChanged += (_, data) =>
        {
            _working.distortion = (bool)data;
            UpdateMenu();
        };

        screenShakeSpinner.SetOptions(enableDisableOptionList);
        screenShakeSpinner.onChanged += (_, data) =>
        {
            _working.screenShake = (bool)data;
            UpdateMenu();
        };

        fullScreenSpinner.SetOptions(enableDisableOptionList);
        fullScreenSpinner.onChanged += (_, data) =>
        {
            _working.fullScreen = (bool)data;
            UpdateResolutionsSpinner();
            UpdateMenu();
        };

        displaySpinner.SetOptions(GetDisplays());
        displaySpinner.SetTextColor(Color.black);
        displaySpinner.onChanged += (_, data) =>
        {
            _working.display = (int)data;
            UpdateResolutionsSpinner();
            UpdateRefreshRatesSpinner();
            UpdateMenu();
        };

        resolutionSpinner.SetOptions(GetDisplayModes(_working.display));
        resolutionSpinner.SetTextColor(Color.black);
        resolutionSpinner.onChanged += (_, data) =>
        {
            _working.modeIndex = (int)data;
            UpdateRefreshRatesSpinner();
            UpdateMenu();
        };

        List<SpinnerOption> refreshRates = GetRefreshRates(_working.display, _working.modeIndex);
        refreshRateSpinner.SetOptions(refreshRates);
        refreshRateSpinner.SetTextColor(Color.black);
        refreshRateSpinner.onChanged += (_, data) =>
        {
            _working.refreshRate = (int)data;
            UpdateMenu();
        };

        wathgrithrFontSpinner.SetOptions(enableDisableOptionList);
        wathgrithrFontSpinner.onChanged += (_, data) =>
        {
            _working.wathgrithrFont = (bool)(data);
            UpdateMenu();
        };
        
        #endregion

        #region 右列设置项

        fxVolumeSpinner.max = 10;
        fxVolumeSpinner.onChanged += (_, data) =>
        {
            _working.fxVolume = (int)data;
            ApplyVolume();
            UpdateMenu();
        };

        musicVolumeSpinner.max = 10;
        musicVolumeSpinner.onChanged += (_, data) =>
        {
            _working.musicVolume = (int)data;
            ApplyVolume();
            UpdateMenu();
        };

        ambientVolumeSpinner.max = 10;
        ambientVolumeSpinner.onChanged += (_, data) =>
        {
            _working.ambientVolume = (int)data;
            ApplyVolume();
            UpdateMenu();
        };

        hudSizeSpinner.max = 10;
        hudSizeSpinner.onChanged += (_, data) =>
        {
            _working.hudSize = (int)data;
            UpdateMenu();
        };

        screenFlashSpinner.SetOptions(enableScreenFlashOptionList);
        screenFlashSpinner.onChanged += (_, data) =>
        {
            _working.screenFlash = (int)data;
            UpdateMenu();
        };

        vibrationSpinner.SetOptions(enableDisableOptionList);
        vibrationSpinner.onChanged += (_, data) =>
        {
            _working.vibration = (bool)data;
            UpdateMenu();
        };

        integratedBackpackSpinner.SetOptions(integratedBackpackOptionList);
        integratedBackpackSpinner.SetTextColor(Color.black);
        integratedBackpackSpinner.onChanged += (_, data) =>
        {
            _working.integratedBackpack = (bool)data;
            UpdateMenu();
        };

        sendStatsSpinner.SetOptions(enableDisableOptionList);
        sendStatsSpinner.onChanged += (_, data) =>
        {
            _working.sendStats = (bool)data;
            if (!((bool)data)) DataCollectionPopup();
            UpdateMenu();
        };

        #endregion
    }
    private void DoInit()
    {
        DoInitPerformancePage();
        DoInitHamletPage();
        DoInitMainPage();
    }
    private int EnabledOptionsIndex(bool optionEnabled)
    {
        return optionEnabled ? 1 : 0;
    }
    private void UpdateDisplaySpinner()
    {
        displaySpinner.SetSelectedIndex(0);
    }
    private void InitializeSpinners()
    {
        fullScreenSpinner.SetSelectedIndex(EnabledOptionsIndex(_working.fullScreen));
        UpdateDisplaySpinner();
        UpdateResolutionsSpinner();
        UpdateRefreshRatesSpinner();
        smallTexturesSpinner.SetSelectedIndex(EnabledOptionsIndex(_working.smallTextures));
        netbookModeSpinner.SetSelectedIndex(EnabledOptionsIndex(_working.netbookMode));
        dynamicLoadingLevelSpinner.SetSelectedIndex(_working.dynamicLoadingLevel);
        
        bloomSpinner.SetSelectedIndex(EnabledOptionsIndex(_working.bloom));
        distortionSpinner.SetSelectedIndex(EnabledOptionsIndex(_working.distortion));
        screenShakeSpinner.SetSelectedIndex(EnabledOptionsIndex(_working.screenShake));
        
        fxVolumeSpinner.SetSelectedIndex(_working.fxVolume);
        musicVolumeSpinner.SetSelectedIndex(_working.musicVolume);
        ambientVolumeSpinner.SetSelectedIndex(_working.ambientVolume);
        
        hudSizeSpinner.SetSelectedIndex(_working.hudSize);
        
        screenFlashSpinner.SetSelectedIndex(_working.screenFlash);
        integratedBackpackSpinner.SetSelectedIndex(EnabledOptionsIndex(_working.integratedBackpack));
        vibrationSpinner.SetSelectedIndex(EnabledOptionsIndex(_working.vibration));
        sendStatsSpinner.SetSelectedIndex(EnabledOptionsIndex(_working.sendStats));
        wathgrithrFontSpinner.SetSelectedIndex(EnabledOptionsIndex(_working.wathgrithrFont));
        
        renderJungleCanopySpinner.SetSelectedIndex(EnabledOptionsIndex(_working.hamlet_render_jungle_canopy));
        renderJungleVinesSpinner.SetSelectedIndex(EnabledOptionsIndex(_working.hamlet_render_jungle_vines));
    }
    private void ShowPage()
    {
        if (_activePage == 1)
        {
            grid.gameObject.SetActive(true);

            foreach (Grid tempGrid in _gridList) tempGrid.grid.SetActive(false);
            
            leftButton.interactable = false;
        }
        else
        {
            grid.gameObject.SetActive(false);


            for (int i = 0; i < _gridList.Count; i++)
            {
                Grid tempGrid = _gridList[i];
                
                if (i == _activePage - 2)
                {
                    tempGrid.grid.SetActive(true);
                    dlcOptionsTitle.text = tempGrid.title;
                }
                else tempGrid.grid.SetActive(false);
            }
            
            
            leftButton.interactable = true;
            rightButton.interactable = _gridList.Count > _activePage - 1;
        }
    }
    private void RefreshControls()
    {
        if (TheInput.ControllerAttached())
        {
            integratedBackpackSpinner.Disable();
            integratedBackpackSpinner.UpdateText("Integrated");
        }
        else integratedBackpackSpinner.Enable();
        
        UpdateMenu();
    }
    public void Start()
    {
        _options = new Options();
        string dynamicLoadingLevelSetting = TheSim.GetSetting("graphics", "dynamic-loading-level");
        if (dynamicLoadingLevelSetting != null)
            _options.dynamicLoadingLevel = int.Parse(dynamicLoadingLevelSetting);
        _working = (Options)_options.Clone();
        
        DLCSupport.SetBGcolor(GetComponent<Image>(), false);
        
        menu.anchoredPosition = new Vector2(260,
            DLCSupport.IsDLCEnabled(DLCSupport.REIGN_OF_GIANTS) ? -320 : -335
        );
        
        DoInit();
        
        InitializeSpinners();
        
        leftButton.onClick.AddListener(() =>
        {
            _activePage--;
            ShowPage();
        });
        rightButton.onClick.AddListener(() =>
        {
            _activePage++;
            ShowPage();
        });
        
        ShowPage();
        RefreshControls();
    }
}