using DYT;
using DYT.Tools;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DLCButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip audioClip;
    public Image background;
    public Image checkBox;
    public Image image;

    private AudioSource audioSource;


    private void Reset()
    {
        background = transform.Find("Background").GetComponent<Image>();
        checkBox = transform.Find("CheckBox").GetComponent<Image>();
        image = transform.Find("Image").GetComponent<Image>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = Main.TheFrontEnd.GetSound();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(audioClip);
        transform.localScale = new Vector3(1.1f, 1.1f, 1);
        background.sprite = ResourcesTool.LoadSprite("Images/SaveTileSmall", "Over");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);
        background.sprite = ResourcesTool.LoadSprite("Images/SaveTileSmall", "Anim");
    }


    protected virtual void OnValueBecomeTrue(){}
    public void OnValueChanged(bool boolean)
    {
        if (boolean)
        {
            checkBox.color = new Color(1, 1, 1, 1);
            checkBox.sprite = ResourcesTool.LoadSprite("Images/ui", "button_checkbox2");

            image.color = new Color(1, 1, 1, 1);
            
            OnValueBecomeTrue();
        }
        else
        {
            checkBox.color = new Color(1, 0.5f, 0.5f, 1);
            checkBox.sprite = ResourcesTool.LoadSprite("Images/ui", "button_checkbox1");

            image.color = new Color(1, 1, 1, 0.3f);
        }
    }
}