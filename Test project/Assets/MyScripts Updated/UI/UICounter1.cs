using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class UICounter1 : MonoBehaviour
{
    [HideInInspector]
    public int max;
    [HideInInspector]
    public int min;
    [HideInInspector]
    public int Count;
    public DrumKit1 Drums;
    public Xylophone Xylophone;
    [HideInInspector]
    public string CurrentInstrument = "DrumKit";
    public TMP_Text MinMaxText;
    
    void Start()
    {
        min = Drums.MinElementsNumber;
        max = Drums.MaxElementsNumber;
        Count = Drums.ElementsNumber;
        UpdateCounter();
    }


    public void UpdateCounter()
    {
        this.GetComponent<TMP_Text>().text = "Nombre d'éléments : " + Count;
        MinMaxText.text = "Min : " + min + " | Max : " + max;
    }

    public void AddElement()
    {
        if (CurrentInstrument == "DrumKit")
        {
            Drums.AddElement();
        } else
        {
            Xylophone.AddElement();
        }
    }

    public void RemoveElement()
    {
        if (CurrentInstrument == "DrumKit")
        {
            Drums.RemoveElement();
        }
        else
        {
            Xylophone.RemoveElement();
        }
    }
    
}
