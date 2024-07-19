using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XylophoneInitializer : MonoBehaviour
{
    public int ElementsNumber = 20;
    public int MinElementsNumber = 5;
    public int MaxElementsNumber = 20;
    [Tooltip("Les clips audio jou�s par les diff�rentes lames de l'instrument, � remplir dans l'ordre de gauche � droite")]
    public AudioClip[] audioClips;
    //public AudioClip clip;
    public GameObject prefab;
    public UICounter counter;

    private readonly float Height = 0.018f;
    private readonly float Length = 0.29f;
    private readonly float Width = 0.038f;
    private GameObject NewTile;
    private Transform Parent;
    [HideInInspector]
    public GameObject[] InstrumentTiles;
    private float red, green, blue;

    void Start()
    {
        InstrumentTiles = new GameObject[MaxElementsNumber];
        Parent = GetComponent<Transform>();
        Initializer();
        this.gameObject.SetActive(false);
    }

    public void Initializer()
    {
        //float x = 0;
        for (int i = 0; i < MaxElementsNumber; i++)
        {
            /*
            if (i <= 10)
            {
                red = 1 - 2*x;
                blue = 0;
                green = 2 * x;
            } else
            {
                red = 0;
                blue = 2 * (x - 0.5f);
                green = -1 + 2*x;
            }
            */
            red = Random.Range(0.0f, 1.0f);
            green = Random.Range(0.0f, 1.0f);
            blue = Random.Range(0.0f, 1.0f);

            
            NewTile = Instantiate(prefab, new Vector3(-0.38f + i * 0.04f, 0.9f, 0.4f + i * 0.0025f), new Quaternion(0, 0, 0, 0), Parent);
            NewTile.GetComponent<AudioSource>().clip = audioClips[i];
            NewTile.transform.localScale = new Vector3(Width, Height, Length - i * 0.005f);
            NewTile.GetComponent<Renderer>().material.color = new Color(red, green, blue);
            NewTile.SetActive(false);
            InstrumentTiles[i] = NewTile;
            //x += 0.05f;
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

}