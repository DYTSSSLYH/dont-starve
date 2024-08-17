using UnityEngine;
using UnityEngine.EventSystems;

public class Option : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public int index;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        ModsScreen modsScreenScript = transform.root.Find("ModsScreen").GetComponent<ModsScreen>();
        modsScreenScript.ShowModDetails(index);

        transform.localScale = new Vector3(1.1f, 1.1f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }
}