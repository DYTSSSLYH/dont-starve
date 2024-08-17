using DYT;
using UnityEngine;

public class HamletDLCButton : DLCButton
{
    public GameObject hamletWarningBigPopupDialogScreen;
    
    
    private void HamletWarning()
    {
        if (GameLogic.Profile.GetHamletClicked()) return;
        
        
        GameLogic.Profile.SetHamletClicked(true);
        GameLogic.Profile.Save(null);

        Instantiate(hamletWarningBigPopupDialogScreen, transform.root);
    }
    protected override void OnValueBecomeTrue()
    {
        HamletWarning();
    }
}