using UnityEngine;
using UnityEngine.UI;

public class ShipwreckedDLCButton : DLCButton
{
    public GameObject hamletCompatibilityBigPopupDialogScreen;
    
    
    protected override void OnValueBecomeTrue()
    {
        Transform instantiateTransform =
            Instantiate(hamletCompatibilityBigPopupDialogScreen, transform.root).transform;

        Button yesButton = instantiateTransform.Find("Menu").Find("YesButton").GetComponent<Button>();
        yesButton.onClick.AddListener(() =>
        {
            Destroy(instantiateTransform.gameObject);
        });
    }
}