using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class UICounter : MonoBehaviour
{
    public int max;
    public int min;
    [HideInInspector]
    public int Count = 2;
    public DrumKit Drums;
    public XylophoneInitializer Xylophone;
    [HideInInspector]
    public string CurrentInstrument = "DrumKit";
    
    void Start()
    {
        this.GetComponent<TMP_Text>().text = "Nombre d'éléments : " + Count;
    }


    public void UpdateCounter()
    {
        this.GetComponent<TMP_Text>().text = "Nombre d'éléments : " + Count;
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
