using System.Collections;
using System.Collections.Generic;
using DYT;
using DYT.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModsScreen : MonoBehaviour
{
    public GameObject haveModDetailPanel;
    public GameObject noModDetailPanel;

    public GameObject modConfigScreenPrefab;

    public int displayRows = 5;
    public GameObject optionPrefab;
    
    public int currentMod;
    public List<string> modNameList;

    public GameObject workshopUpdateNotePrefab;

    
    private int optionOffset;
    private Button upButton;
    private Button downButton;
    private Transform main;

    private TextMeshProUGUI _workshopUpdateNote;
    
    
    
    public void ModLinkCurrent()
    {
        string modName = modNameList[currentMod];
        string url = KnownModIndex.GetModInfo(modName).forumThread;
        Main.VisitURL(url);
    }

    public void MoreMods()
    {
        Main.VisitURL("https://steamcommunity.com/app/219740/workshop/");
    }

    public void ShowModDetails(int index)
    {
        currentMod = index;
        
        string modName = modNameList[index];
        KnownModIndex.ModInfo modInfo = KnownModIndex.GetModInfo(modName);
        Transform detailPanel = transform.Find("HaveModDetailPanel");
        
        Image detailImage = detailPanel.Find("DetailImage").GetComponent<Image>();
        detailImage.sprite = ResourcesTool.LoadSprite("Mods/" + modName + modInfo.iconAtlas, modInfo.icon);
        
        TextMeshProUGUI detailTitle = detailPanel.Find("DetailTitle").GetComponent<TextMeshProUGUI>();
        if (modInfo.name != null) detailTitle.text = modInfo.name;
        else detailTitle.text = modName;
        
        TextMeshProUGUI detailAuthor = detailPanel.Find("DetailAuthor").GetComponent<TextMeshProUGUI>();
        detailAuthor.text = $"by {modInfo.author}";
        
        TextMeshProUGUI detailDescription = detailPanel.Find("DetailDescription").GetComponent<TextMeshProUGUI>();
        detailDescription.text = modInfo.description;
        
        TextMeshProUGUI modLinkButton =
            detailPanel.Find("ModLinkButton").Find("Text").GetComponent<TextMeshProUGUI>();
        if (modInfo.forumThread == "http://forums.kleientertainment.com/index.php?/forum/26-dont-starve-mods-and-tools/")
            modLinkButton.text = "Mod discussion forums";
        else modLinkButton.text = "Take me to the mod page!";
        
        TextMeshProUGUI detailCompatibility =
            detailPanel.Find("DetailCompatibility").GetComponent<TextMeshProUGUI>();
        if (modInfo.dontStarveCompatible &&
            modInfo.reginOfGiantsCompatible && modInfo.shipwreckedCompatible && modInfo.hamletCompatible)
        {
            if (!modInfo.dontStarveCompatibilitySpecified && modInfo.reginOfGiantsCompatibilitySpecified &&
                modInfo.shipwreckedCompatibilitySpecified && modInfo.hamletCompatibilitySpecified)
                detailCompatibility.text = "Compatibility unknown.";
            else detailCompatibility.text = "Compatible with everything.";
        }
        else if (modInfo.dontStarveCompatible &&
            !modInfo.reginOfGiantsCompatible && !modInfo.shipwreckedCompatible && !modInfo.hamletCompatible)
            detailCompatibility.text = "Compatible with Don't Starve only.";
        else if (modInfo.reginOfGiantsCompatible &&
            !modInfo.dontStarveCompatible && !modInfo.shipwreckedCompatible && !modInfo.hamletCompatible)
            detailCompatibility.text = "Compatible with Reign of Giants only.";
        else if (modInfo.shipwreckedCompatible &&
            !modInfo.dontStarveCompatible && !modInfo.reginOfGiantsCompatible && !modInfo.hamletCompatible)
            detailCompatibility.text = "Compatible with Shipwrecked only.";
        else if (modInfo.hamletCompatible &&
            !modInfo.dontStarveCompatible && !modInfo.reginOfGiantsCompatible && !modInfo.shipwreckedCompatible)
            detailCompatibility.text = "Compatible with Hamlet only.";
        else if (modInfo.dontStarveCompatible ||
            modInfo.reginOfGiantsCompatible || modInfo.shipwreckedCompatible || modInfo.hamletCompatible)
            detailCompatibility.text = "";
        else detailCompatibility.text = "Compatible with nothing. I'm sure it's fine.";

        GameObject modConfigButton = transform.Find("MainMenu").Find("ModConfigButton").gameObject;
        modConfigButton.SetActive(KnownModIndex.HasModConfigurationOptions(modName));
        
        TextMeshProUGUI detailWarning = detailPanel.Find("DetailWarning").GetComponent<TextMeshProUGUI>();
        string modStatus = GetBestModStatus(modName);
        if (modStatus == "WORKING_NORMALLY") detailWarning.text = "Mod is installed.";
        else if (modStatus == "WILL_ENABLE") detailWarning.text = "Mod will be enabled.";
        else if (modStatus == "WILL_DISABLE") detailWarning.text = "Mod will be disabled.";
        else if (modStatus == "DISABLED_ERROR")
        {
            detailWarning.color = new Color(0.9f, 0.3f, 0.3f, 1);
            detailWarning.text = "Crashed on last start, automatically disabled.";
        }
        else if (modStatus == "DISABLED_OLD")
        {
            detailWarning.color = new Color(0.8f, 0.8f, 0.3f, 1);
            detailWarning.text = "Mod out-of-date, might have issues. Disabled.";
        }
        else if (modStatus == "DISABLED_MANUAL") detailWarning.text = "This mod has been disabled.";
    }
    
    
    private void Apply()
    {
        KnownModIndex.Save();
        Destroy(gameObject);
    }
    private void Cancel()
    {
        KnownModIndex.RestoreCachedSaveData(null);
        Destroy(gameObject);
    }
    
    private string GetBestModStatus(string modName)
    {
        if (KnownModIndex.IsModEnabled(modName))
            if (KnownModIndex.WasModEnabled(modName)) return "WORKING_NORMALLY";
            else return "WILL_ENABLE";
        else
        if (KnownModIndex.WasModEnabled(modName)) return "WILL_DISABLE";
        else
        if (KnownModIndex.GetModInfo(modName).failed || KnownModIndex.IsModKnownBad(modName))
            return "DISABLED_ERROR";
        else if (KnownModIndex.GetModInfo(modName).old) return "DISABLED_OLD";
        else return "DISABLED_MANUAL";
    }
    private void RefreshOptions()
    {
        for (int i = 0; i < main.childCount; i++) Destroy(main.GetChild(i).gameObject);
        
        int end = Mathf.Min(optionOffset + displayRows, modNameList.Count);
        for (int i = optionOffset; i < end; i++)
        {
            string modName = modNameList[i];
            KnownModIndex.ModInfo modInfo = KnownModIndex.GetModInfo(modName);

            GameObject option = Instantiate(optionPrefab, main);
            option.GetComponent<Option>().index = i;
            Transform optionTransform = option.transform;

            Image image = optionTransform.Find("Image").GetComponent<Image>();
            if (modInfo.iconAtlas != null && modInfo.icon != null)
                image.sprite =
                    ResourcesTool.LoadSprite("mods/" + modName + "/" + modInfo.iconAtlas, modInfo.icon);

            TextMeshProUGUI nameText = optionTransform.Find("Name").GetComponent<TextMeshProUGUI>();
            nameText.text = modName;
            if (modInfo.name != null) nameText.text = modInfo.name;

            TextMeshProUGUI status = optionTransform.Find("Status").GetComponent<TextMeshProUGUI>();
            status.text = modName;
            string modStatus = GetBestModStatus(modName);
            if (modStatus == "WORKING_NORMALLY") status.text = "Enabled";
            else if (modStatus == "WILL_ENABLE") status.text = "To Be Enabled";
            else if (modStatus == "WILL_DISABLE")
            {
                status.color = new Color(0.7f, 0.7f, 0.7f, 1);
                status.text = "To Be Disabled";
            }
            else if (modStatus == "DISABLED_ERROR")
            {
                status.color = new Color(0.9f, 0.3f, 0.3f, 1);
                status.text = "Crashed!";
            }
            else if (modStatus == "DISABLED_OLD")
            {
                status.color = new Color(0.8f, 0.8f, 0.3f, 1);
                status.text = "Out-of-date!";
            }
            else if (modStatus == "DISABLED_MANUAL")
            {
                status.color = new Color(0.7f, 0.7f, 0.7f, 1);
                status.text = "Disabled";
            }
            
            Image hamletCompatible = optionTransform.Find("HamletCompatible").GetComponent<Image>();
            if (modInfo.hamletCompatible)
            {
                if (modInfo.hamletCompatibilitySpecified == false)
                    hamletCompatible.sprite = ResourcesTool.LoadSprite("Images/ui", "ham_unknown");
                else hamletCompatible.sprite = ResourcesTool.LoadSprite("Images/ui", "ham_on");
            }
            
            Image shipwreckedCompatible = optionTransform.Find("ShipwreckedCompatible").GetComponent<Image>();
            if (modInfo.shipwreckedCompatible)
            {
                if (modInfo.shipwreckedCompatibilitySpecified == false)
                    shipwreckedCompatible.sprite = ResourcesTool.LoadSprite("Images/ui", "sw_unknown");
                else shipwreckedCompatible.sprite = ResourcesTool.LoadSprite("Images/ui", "sw_on");
            }
            
            Image reginOfGaintsCompatible =
                optionTransform.Find("ReginOfGaintsCompatible").GetComponent<Image>();
            if (modInfo.reginOfGiantsCompatible)
            {
                if (modInfo.reginOfGiantsCompatibilitySpecified == false)
                    reginOfGaintsCompatible.sprite = ResourcesTool.LoadSprite("Images/ui", "rog_unknown");
                else reginOfGaintsCompatible.sprite = ResourcesTool.LoadSprite("Images/ui", "rog_on");
            }
            
            Image dontStarveCompatible = optionTransform.Find("DontStarveCompatible").GetComponent<Image>();
            if (modInfo.dontStarveCompatible)
            {
                if (modInfo.dontStarveCompatibilitySpecified == false)
                    dontStarveCompatible.sprite = ResourcesTool.LoadSprite("Images/ui", "ds_unknown");
                else dontStarveCompatible.sprite = ResourcesTool.LoadSprite("Images/ui", "ds_on");
            }

            Image checkBox = optionTransform.Find("CheckBox").GetComponent<Image>();
            if (KnownModIndex.IsModEnabled(modName))
            {
                image.color = Color.white;
                checkBox.sprite = ResourcesTool.LoadSprite("Images/ui", "button_checkbox2");
                checkBox.color = Color.white;
                nameText.color = Color.white;
                hamletCompatible.color = Color.white;
                shipwreckedCompatible.color = Color.white;
                reginOfGaintsCompatible.color = Color.white;
                dontStarveCompatible.color = Color.white;
            }
            else
            {
                Color color = new Color(1, 0.5f, 0.5f, 1);
                image.color = color;
                checkBox.sprite = ResourcesTool.LoadSprite("Images/ui", "button_checkbox1");
                checkBox.color = color;
                nameText.color = new Color(1, 0.5f, 0.5f, 1);
                hamletCompatible.color = color;
                shipwreckedCompatible.color = color;
                reginOfGaintsCompatible.color = color;
                dontStarveCompatible.color = color;
            }
        }
    }
    private void Scroll(int dir)
    {
        optionOffset += dir;
        
        RefreshOptions();

        if (!upButton.interactable && optionOffset >= displayRows) upButton.interactable = true;
        else if (upButton.interactable && optionOffset < displayRows) upButton.interactable = false;

        if (!downButton.interactable && optionOffset + displayRows < modNameList.Count)
            downButton.interactable = true;
        else if (downButton.interactable && optionOffset + displayRows >= modNameList.Count)
            downButton.interactable = false;
    }
    
    private IEnumerator StartWorkshopUpdate()
    {
        while (true)
        {
            if (_workshopUpdateNote == null)
                _workshopUpdateNote = Instantiate(workshopUpdateNotePrefab, transform.root)
                    .transform.Find("Text").GetComponent<TextMeshProUGUI>();

            Dictionary<string, string> status = TheSim.GetWorkshopUpdateStatus();
            string stateText = "";
            if (status["state"] == "list") stateText = "Checking Workshop subscriptions...";
            else if (status["state"] == "details") stateText = "Verifying mod details...";
            else if (status["state"] == "download")
                stateText = $"Downloading mods:\n {status["progress"]} percent";
            
            _workshopUpdateNote.text = stateText;
            
            if (status["progress"] == "100") break;
            
            yield return new WaitForSeconds(0.2f);
        }
        
        Destroy(_workshopUpdateNote.transform.parent.gameObject);
        _workshopUpdateNote = null;
        
        KnownModIndex.UpdateModInfo();
        List<string> modNames = KnownModIndex.GetModNames();
        
        Debug.Log("Reloading Mod Info Prefabs");

        Instantiate(modNameList.Count > 0 ? haveModDetailPanel : noModDetailPanel, transform);
        
        Scroll(0);
        
        if (modNameList.Count > 0) ShowModDetails(0);
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        KnownModIndex.CacheSaveData();

        DLCSupport.SetBGcolor(GetComponent<Image>(), false);

        Transform mainMenu = transform.Find("MainMenu");
        Button applyButton = mainMenu.Find("ApplyButton").GetComponent<Button>();
        applyButton.onClick.AddListener(Apply);
        Button cancelButton = mainMenu.Find("CancelButton").GetComponent<Button>();
        cancelButton.onClick.AddListener(Cancel);
        Button modConfigButton = mainMenu.Find("ModConfigButton").GetComponent<Button>();
        modConfigButton.onClick.AddListener(() =>
        {
            GameObject modConfigScreen = Instantiate(modConfigScreenPrefab, transform.parent);
            modConfigScreen.GetComponent<ModConfigScreen>().modName = modNameList[currentMod];
        });
        Button moreButton = mainMenu.Find("MoreButton").GetComponent<Button>();
        moreButton.onClick.AddListener(() => Main.VisitURL("https://steamcommunity.com/app/219740/workshop/"));

        optionOffset = 0;
        Transform optionsPanel = transform.Find("OptionsPanel");
        main = optionsPanel.Find("Main");
        upButton = optionsPanel.Find("UpButton").GetComponent<Button>();
        upButton.onClick.AddListener(() => Scroll(-displayRows));
        downButton = optionsPanel.Find("DownButton").GetComponent<Button>();
        downButton.onClick.AddListener(() => Scroll(displayRows));

        StartCoroutine(StartWorkshopUpdate());
    }
}