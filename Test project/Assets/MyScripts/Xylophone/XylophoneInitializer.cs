using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XylophoneInitializer : MonoBehaviour
{
    public int ElementsNumber = 20;
    public int MinElementsNumber = 5;
    public int MaxElementsNumber = 20;
    [Tooltip("Les clips audio joués par les différentes lames de l'instrument, à remplir dans l'ordre de gauche à droite")]
    public AudioClip[] audioClips; 
    public GameObject prefab;
    public UICounter counter;

    private readonly float Length = 0.29f;
    private GameObject NewTile;
    private Transform Parent;
    private GameObject[] InstrumentTiles;

    void Start()
    {
        audioClips = new AudioClip[MaxElementsNumber];
        InstrumentTiles = new GameObject[MaxElementsNumber];
        Parent = GetComponent<Transform>();
        Initializer();
    }

    public void Initializer()
    {
        for (int i = 0; i < MaxElementsNumber; i++)
        {
            NewTile = Instantiate(prefab, new Vector3(-0.38f + i * 0.04f, 0.9f, i * 0.025f), new Quaternion(0, 0, 0, 0), Parent);
            NewTile.GetComponent<AudioSource>().clip = audioClips[i];
            NewTile.transform.localScale = new Vector3(1, 1, Length - i * 0.05f);
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
        counter.Count = ElementsNumber;
        counter.max = MaxElementsNumber;
        counter.min = MinElementsNumber;
        counter.UpdateCounter();
    }

    public void Display()
    {
        for (int i = ElementsNumber; i < MaxElementsNumber; i++)
        {
            InstrumentTiles[i].SetActive(false);
        }
    }

}
