using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Interact with "InstrumentPositionCanvas" elements and the drums to work with "DrumPosition.cs"
public class MasterController : MonoBehaviour
{
    public GameObject[] Drums = new GameObject[5]; // the 5 elements of the instrument (3 drums and 2 cymbals) 
    public GameObject dropdown; // Dropdown for the position (Gauche/Centre/Droite)
    public GameObject slider; // Slider for the position (0<=Value<=1)
    public GameObject SliderText; // text that display the angle
    public GameObject xrRig; // the player
    public GameObject Anchor; // Teleportation Anchor
    private int nbDrum = 1;

    // Init the drums position
    public void Start()
    {
        for (int i = 0; i < Drums.Length; i++)
        {
            this.Drums[i].GetComponent<DrumPosition>().InitPos(i);
        }
    }

    // Call for ChangePos function of DrumPosition.cs
    public void PosDrum(float value)
    {
        for (int i = 0; i < Drums.Length; i++)
        {
            this.Drums[i].GetComponent<DrumPosition>().ChangePos(value);
        }

    }

    // Call for SetPos function of DrumPosition.cs
    public void SetDrum(int value)
    {

        for (int i = 0; i < Drums.Length; i++)
        {
            this.Drums[i].GetComponent<DrumPosition>().SetPos(value);
        }
    }

    // Update other UI elements according to the Dropdown
    public void NotifyFromDropdown()
    {
        switch (this.dropdown.GetComponent<Dropdown>().value)
        {
            case 0:
                this.slider.GetComponent<Slider>().value = 0;
                break;
            case 1:
                this.slider.GetComponent<Slider>().value = 0.5f;
                break;
            case 2:
                this.slider.GetComponent<Slider>().value = 1;
                break;
        }
        this.SetDrum(this.dropdown.GetComponent<Dropdown>().value);
    }

    // Update Dropdown text
    public void UpdateDropdownText()
    {
        dropdown.GetComponentInChildren<TMP_Text>().text = dropdown.GetComponent<Dropdown>().options[dropdown.GetComponent<Dropdown>().value].text;
    }

    // Update other UI elements according to the Slider
    public void NotifyFromSlider()
    {
        switch (this.slider.GetComponent<Slider>().value)
        {
            case 0f:
                this.dropdown.GetComponent<Dropdown>().value = 0;
                break;
            case 0.5f:
                this.dropdown.GetComponent<Dropdown>().value = 1;
                break;
            case 1f:
                this.dropdown.GetComponent<Dropdown>().value = 2;
                break;
        }
        this.PosDrum(this.slider.GetComponent<Slider>().value);
    }

    // Reset Drums position 
    public void Reset()
    {
        this.slider.GetComponent<Slider>().value = 0.5f;
        this.dropdown.GetComponent<Dropdown>().value = 1;
        this.SetDrum(1);
    }

    // Add a drum if it's possible
    public void AddDrum()
    {

        if (this.nbDrum > 4)
        {
            Debug.Log("Trop");
        }
        else
        {
            this.Drums[this.nbDrum].SetActive(true);
            this.nbDrum += 1;
        }

    }

    // Delete a drum if it's possible
    public void SuppDrum()
    {
        if (this.nbDrum > 1)
        {
            this.Drums[nbDrum - 1].SetActive(false);
            this.nbDrum -= 1;
            Debug.Log("Suppr");
        }
        else
        {
            Debug.Log("Il n'y a qu'un seul tambour");
        }
    }

    // Update the slider text that display the angle.
    public void SetTextSlider()
    {
        SliderText.GetComponent<TMP_Text>().text = Mathf.Round((slider.GetComponent<Slider>().value - 0.5f) * 180).ToString() + "°";
    }




}