using System;
using UnityEngine;

public class DLCCompatibilityPrompt : MonoBehaviour
{
    public Action<DLCCompatibilityPrompt> doneAction;
    
    
    // Start is called before the first frame update
    // private void Start(){}
    // Update is called once per frame
    // private void Update(){}


    public void OnOk()
    {
        if (doneAction != null) doneAction(this);
    }

    public void OnCancel()
    {
        Destroy(gameObject);
    }
}