using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MotdImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public RectTransform motd;
    public Button _motdButton;
    
    
    // Start is called before the first frame update
    // private void Start()
    // {
    // }
    
    // // Update is called once per frame
    // void Update()
    // {
    //     
    // }

    public void OnPointerEnter(PointerEventData eventData)
    {
        motd.localScale = new Vector3(0.93f, 0.93f, 0.93f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        motd.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _motdButton.OnPointerClick(null);
    }
}