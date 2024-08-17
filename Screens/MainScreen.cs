using DYT;
using UnityEngine;
using UnityEngine.UI;
using Screen = DYT.Widgets.Screen;

public class MainScreen : Screen
{
    public GameObject menuPrefab;
    
    
    public GameObject gameScreen;
    public GameObject modsScreen;
    
    public GameObject optionMenuPrefab;
    public GameObject optionsScreen;
    
    public GameObject exitScreenPrefab;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        Transform rightColumn = transform.Find("RightColumn");
        Transform menu = Instantiate(menuPrefab, rightColumn).transform;
        
        menu.Find("Play").GetComponent<Button>()
            .onClick.AddListener(() => Instantiate(gameScreen, transform.parent));
        
        menu.Find("Mods").GetComponent<Button>()
            .onClick.AddListener(() => Instantiate(modsScreen, transform.parent));
        
        menu.Find("Options").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(menu.gameObject);
            Transform optionMenu = Instantiate(optionMenuPrefab, rightColumn).transform;
            
            optionMenu.Find("Settings").GetComponent<Button>().onClick.AddListener(() =>
            {
                Instantiate(optionsScreen, transform.root);
            });
            
            optionMenu.Find("MoreGames").GetComponent<Button>().onClick.AddListener(() =>
                Main.VisitURL("http://store.steampowered.com/search/?developer=Klei%20Entertainment")
            );
            
            optionMenu.Find("Cancel").GetComponent<Button>().onClick.AddListener(() =>
            {
                Destroy(optionMenu.gameObject);
                Start();
            });
        });
        
        menu.Find("Exit").GetComponent<Button>().onClick.AddListener(() =>
        {
            GameObject exitScreen = Instantiate(exitScreenPrefab, transform.parent);
            exitScreen.transform.Find("Menu").Find("Yes").GetComponent<Button>()
                .onClick.AddListener(MainFunctions.RequestShutdown);
        });
    }
}