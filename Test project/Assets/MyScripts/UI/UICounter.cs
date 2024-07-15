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
    //private GameObject[] InstrumentElements = new GameObject[5];
    private string CurrentInstrument = "DrumKit";
    
    void Start()
    {
        this.GetComponent<TMP_Text>().text = "Nombre d'éléments : " + Count;
        //GameObject.Find("ConfigurationResetButton").GetComponent<ResetConfiguration>().InstrumentElements.CopyTo(InstrumentElements,0);
        GameObject.Find("ResetConfigCanva").SetActive(false);
    }


    public void UpdateCounter()
    {
        this.GetComponent<TMP_Text>().text = "Nombre d'éléments : " + Count;
    }


    public void InstrumentChange()
    {
        switch(CurrentInstrument)
        {
            case "DrumKit":
                Xylophone.gameObject.SetActive(false);
                Drums.gameObject.SetActive(true);
                Drums.OnInstrumentChangeToDrumKit();
                break;
            case "Xylophone":
                Drums.gameObject.SetActive(false);
                Xylophone.gameObject.SetActive(true);
                Xylophone.OnInstrumentChangeToXylophone();
                break;
        }
    }
    /*
    public void AddCounter()
    {
        if (Count < max)
        {
            InstrumentElements[Count].SetActive(true);
            Count++;
            UpdateCounter();
        }
    }

    public void DecreaseCounter()
    {
        if (Count > min)
        {
            Count--;
            InstrumentElements[Count].SetActive(false);
            UpdateCounter();
        }
    }*/
}
