using System;
using DYT;
using DYT.Tools;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveTile : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public AudioClip audioClip;
    public RectTransform baseRectTransform;
    public RectTransform backgroundRectTransform;
    public Image backgroundImage;

    public Action onClickTile;


    private void Reset()
    {
        GetComponent<AudioSource>();
        baseRectTransform = (RectTransform)transform.Find("Base");
        backgroundRectTransform = (RectTransform)baseRectTransform.Find("Background");
        if (backgroundRectTransform != null) backgroundImage = backgroundRectTransform.GetComponent<Image>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Main.TheFrontEnd.GetSound().PlayOneShot(audioClip);
        backgroundRectTransform.localScale = new Vector3(1.05f, 0.87f, 1);
        backgroundImage.sprite = ResourcesTool.LoadSprite("Images/SaveTile", "over");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        baseRectTransform.anchoredPosition = Vector2.zero;
        backgroundRectTransform.localScale = new Vector3(1, 0.8f, 1);
        backgroundImage.sprite = ResourcesTool.LoadSprite("Images/SaveTile", "anim");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        baseRectTransform.anchoredPosition = new Vector2(0, -5);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        baseRectTransform.anchoredPosition = Vector2.zero;
        if (onClickTile != null) onClickTile();
    }
}
