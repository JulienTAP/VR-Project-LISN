using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Xylophone : MonoBehaviour
{
    [HideInInspector]
    public int ElementsNumber = 20;
    [HideInInspector]
    public int MinElementsNumber = 5;
    [HideInInspector]
    public int MaxElementsNumber = 20;
    [Tooltip("Les clips audio joués par les différentes lames de l'instrument, à remplir dans l'ordre de gauche à droite")]
    public AudioClip[] audioClips = new AudioClip[20];
    public GameObject prefab;
    public UICounter1 counter;

    private readonly float Height = 0.018f;
    private readonly float Length = 0.29f;
    private readonly float Width = 0.038f;
    private GameObject NewTile;
    private Transform Parent;
    [HideInInspector]
    public GameObject[] InstrumentTiles;
    private float red, green, blue;
    private float ZInitPos;

    public Slider slider;
    public Dropdown dropdown;
    public Toggle T;

    private Vector3 InitialPosition;
    private Quaternion InitialRotation;

    void Start()
    {
        InstrumentTiles = new GameObject[MaxElementsNumber];
        Parent = GetComponent<Transform>();
        InitialPosition = Parent.position;
        InitialRotation = Parent.rotation;
        Initializer();
        //TogglePlayOnTriggerComponent(false);
        this.gameObject.SetActive(false);
    }

    public void Initializer()
    {
        for (int i = 0; i < MaxElementsNumber; i++)
        {
            red = Random.Range(0.0f, 1.0f);
            green = Random.Range(0.0f, 1.0f);
            blue = Random.Range(0.0f, 1.0f);


            NewTile = Instantiate(prefab, new Vector3(Parent.position.x - i * 0.0025f, Parent.position.y, - 0.48f + i * 0.05f), new Quaternion(0, 0, 0, 0), Parent) ;
            NewTile.GetComponent<AudioSource>().clip = audioClips[i];
            NewTile.transform.localScale = new Vector3(Width, Height, Length - (20-i) * 0.005f);
            NewTile.transform.eulerAngles = new Vector3(0, 90, 0);
            NewTile.GetComponent<Renderer>().material.color = new Color(red, green, blue);
            NewTile.SetActive(false);
            InstrumentTiles[i] = NewTile;
        }

    }

    public void AddElement()
    {
        if(ElementsNumber < MaxElementsNumber)
        {
            InstrumentTiles[ElementsNumber++].SetActive(true);
            counter.Count = ElementsNumber;
            counter.UpdateCounter();
        }
    }

    public void RemoveElement()
    {
        if(ElementsNumber > MinElementsNumber)
        {
            InstrumentTiles[--ElementsNumber].SetActive(false);
            counter.Count = ElementsNumber;
            counter.UpdateCounter();
        }
    }

    public void OnInstrumentChangeToXylophone()
    {
        counter.max = MaxElementsNumber;
        counter.min = MinElementsNumber;
        counter.CurrentInstrument = "Xylophone";
        counter.Count = ElementsNumber;
        counter.UpdateCounter();
        DisplayInstrument();
    }

    public void DisplayInstrument()
    {
        for (int i = 0; i < ElementsNumber; i++)
        {
            InstrumentTiles[i].SetActive(true);
        }
    }

    public void Hide()
    {
        for (int i = 0; i < ElementsNumber; i++)
        {
            InstrumentTiles[i].SetActive(false);
        }
    }

    public void SliderMove()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, ZInitPos - (slider.value - 0.5f));
    }

    public void ToggleXyloGrabInteractions()
    {
        GetComponent<XRGrabInteractable>().enabled = T.isOn;
    }

    public void ResetXylophone()
    {
        Parent.SetPositionAndRotation(InitialPosition, InitialRotation);
        slider.value = 0.5f;
    }

    public void GetControllers()
    {
        foreach (GameObject tile in InstrumentTiles)
        {
            tile.GetComponent<PlayOnTrigger1>().GetControllers();
        }
    }

    public void TogglePlayOnTriggerComponent(bool isOn)
    {
        foreach(GameObject tile in InstrumentTiles)
        {
            tile.GetComponent<PlayOnTrigger1>().enabled = isOn;
        }
    }

    public void TogglePlayMode(bool isOn)
    {
        //TogglePlayOnTriggerComponent(!isOn);
        GetControllers();
        GetComponent<XRGrabInteractable>().enabled = !isOn;
    }
}
