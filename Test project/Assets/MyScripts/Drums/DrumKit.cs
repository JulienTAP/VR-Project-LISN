using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;

public class DrumKit : MonoBehaviour
{
    public int ElementsNumber = 2;
    public int MinElementsNumber = 2;
    public int MaxElementsNumber = 5;
    public UICounter counter;

    public GameObject[] InstrumentElements;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=ElementsNumber; i<MaxElementsNumber; i++)
        {
            InstrumentElements[i].SetActive(false);
        }
    }


    public void AddElement()
    {
        if (ElementsNumber < MaxElementsNumber)
        {
            InstrumentElements[ElementsNumber++].SetActive(true);
            counter.Count = ElementsNumber;
            counter.UpdateCounter();
        }
    }

    public void RemoveElement()
    {
        if (ElementsNumber > MinElementsNumber)
        {
            InstrumentElements[--ElementsNumber].SetActive(false);
            counter.Count = ElementsNumber;
            counter.UpdateCounter();
        }
    }

    public void OnInstrumentChangeToDrumKit()
    {
        counter.max = MaxElementsNumber;
        counter.min = MinElementsNumber;
        counter.Count = ElementsNumber;
        counter.UpdateCounter();
        counter.CurrentInstrument = "DrumKit";
        DisplayInstrument();
    }

    public void Hide()
    {
        for (int i = 0; i < ElementsNumber; i++)
        {
            InstrumentElements[i].SetActive(false);
        }
    }

    public void DisplayInstrument()
    {
        for (int i = 0; i < ElementsNumber; i++)
        {
            InstrumentElements[i].SetActive(true);
        }
    }

}
