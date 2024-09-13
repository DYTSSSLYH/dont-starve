using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpinnerOption
{
    public string text;
    public object data;
    public Dictionary<string, object> otherInfoDictionary { get; }

    public SpinnerOption(){}
    public SpinnerOption(string text, object data)
    {
        this.text = text;
        this.data = data;
    }
        
    public SpinnerOption(string text, object data, Dictionary<string, object> otherInfoDictionary)
    {
        this.text = text;
        this.data = data;
        this.otherInfoDictionary = otherInfoDictionary;
    }
}

public class Spinner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Action<object, object> onChanged { get; set; }
    
    [Header("Background相关属性")]
    public Sprite backgroundEndNormal;
    public Sprite backgroundMiddleNormal;
    public Sprite backgroundEndFocus;
    public Sprite backgroundMiddleFocus;
    public Image backgroundStartCap;
    public Image backgroundEndCap;
    public Image[] backgroundFillerArray;
    
    [Header("其余UI相关属性")]
    public TextMeshProUGUI text;
    public Button leftButton;
    public Button rightButton;
    
    
    protected int selectedIndex;                                                                             
    
    private List<SpinnerOption> optionList;
    
    private Color _textColor;


    private void Reset()
    {
        Transform background = transform.Find("Background");
        int backgroundChildCount = background.childCount;
        backgroundStartCap = background.GetChild(0).GetComponent<Image>();
        backgroundEndCap = background.GetChild(backgroundChildCount - 1).GetComponent<Image>();
        backgroundFillerArray = new Image[backgroundChildCount - 2];
        
        for (int i = 1; i <= background.childCount - 2; i++)
            backgroundFillerArray[i - 1] = background.GetChild(i).GetComponent<Image>();
        
        
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        leftButton = transform.Find("LeftButton").GetComponent<Button>();
        rightButton = transform.Find("RightButton").GetComponent<Button>();
    }

    private void Start()
    {
        _textColor = text.color;
        if (selectedIndex == 0) SetSelectedIndex(0);
        
        leftButton.onClick.AddListener(() =>
        {
            object preData = GetSelectedData();
            SetSelectedIndex(selectedIndex - 1);
            if (onChanged != null) onChanged(preData, GetSelectedData());
        });
        rightButton.onClick.AddListener(() =>
        {
            object preData = GetSelectedData();
            SetSelectedIndex(selectedIndex + 1);
            if (onChanged != null) onChanged(preData, GetSelectedData());
        });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        backgroundStartCap.sprite = backgroundEndFocus;
        backgroundEndCap.sprite = backgroundEndFocus;
        
        foreach (Image backgroundFiller in backgroundFillerArray)
            backgroundFiller.sprite = backgroundMiddleFocus;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        backgroundStartCap.sprite = backgroundEndNormal;
        backgroundEndCap.sprite = backgroundEndNormal;
        
        foreach (Image backgroundFiller in backgroundFillerArray)
            backgroundFiller.sprite = backgroundMiddleNormal;
    }


    protected virtual int GetMaxIndex()
    {
        return optionList.Count - 1;
    }
    private void UpdateButtonState()
    {
        leftButton.interactable = true;
        rightButton.interactable = true;
        
        if (selectedIndex <= 0) leftButton.interactable = false;
        if (selectedIndex >= GetMaxIndex()) rightButton.interactable = false;
    }
    
    public void Enable()
    {
        text.color = _textColor;
        UpdateButtonState();
    }
    public void Disable()
    {
        text.color = new Color(0.4f, 0.4f, 0.4f, 1);
        leftButton.interactable = false;
        rightButton.interactable = false;
    }

    public int GetSelectedIndex()
    {
        return selectedIndex;
    }
    protected virtual string GetSelectedText()
    {
        return optionList[selectedIndex].text;
    }
    public virtual object GetSelectedData()
    {
        return optionList[selectedIndex].data;
    }
    public SpinnerOption GetSelected()
    {
        return optionList[selectedIndex];
    }
    
    public void SetSelectedIndex(int index)
    {
        selectedIndex = index;
        text.text = GetSelectedText();
        UpdateButtonState();
    }
    public void SetSelected(object data)
    {
        for (int i = 0; i < optionList.Count; i++)
        {
            if (optionList[i].data == data)
            {
                SetSelectedIndex(i);
                return;
            }
        }
    }

    public void SetOptions(List<SpinnerOption> optionList)
    {
        selectedIndex = 0;
        this.optionList = optionList;
        SetSelectedIndex(0);
    }
    public void UpdateText(string msg)
    {
        text.text = msg;
    }
    public void SetTextColor(Color color)
    {
        _textColor = color;
        text.color = color;
    }
}