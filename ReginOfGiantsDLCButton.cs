using UnityEngine;

public class ReginOfGiantsDLCButton : DLCButton
{
    public GameObject dlcCompatibilityPromptPrefab;
    
    
    protected override void OnValueBecomeTrue()
    {
        DLCCompatibilityPrompt dlcCompatibilityPrompt =
            Instantiate(dlcCompatibilityPromptPrefab, transform.root).GetComponent<DLCCompatibilityPrompt>();

        dlcCompatibilityPrompt.doneAction += prompt => Destroy(prompt.gameObject);
    }
}