using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class DrumKit : MonoBehaviour
{
    //The base class to deal with drumkit's elements visibility and behavior regarding UI
 
    //The actual number of elements displayed on the scene when the drum kit is selected, it has to be between min and max values
    public int ElementsNumber;

    //The minimum number of elements, should be positive and less than max value
    public int MinElementsNumber;

    //The maximum number of elements, should be positive, greater than min value and has to be less or equal than 5
    public int MaxElementsNumber;
    //Recommended values are 1,1,5

    //The counter to update when an element is added
    public UICounter counter;

    //The toggle object that allows the user to grab the elements
    public Toggle T;

    //An array with the 5 elements of the drum kit
    public GameObject[] InstrumentElements;

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
    public void SetDrumsGrabInteractions(bool isOn)
    {
        foreach (GameObject drum in InstrumentElements)
        {
            drum.GetComponent<XRGrabInteractable>().enabled = isOn;
            drum.GetComponent<BoxCollider>().enabled = isOn;
        }
    }


    public void ToggleDrumsGrabInteractions()
    {
        SetDrumsGrabInteractions(T.isOn);
    }


    public void GetController(string tag)
    {
        foreach(GameObject drum in InstrumentElements)
        {
            drum.GetComponentInChildren<PlayOnTrigger>().GetController(tag);
        }
    }

    public void RemoveController(string tag)
    {
        foreach (GameObject drum in InstrumentElements)
        {
            drum.GetComponentInChildren<PlayOnTrigger>().RemoveController(tag);
        }
    }


    public void TogglePlayOnTriggerComponent(bool isOn)
    {
        foreach (GameObject drum in InstrumentElements)
        {
            drum.GetComponentInChildren<PlayOnTrigger>().enabled = isOn;
        }
    }

}
