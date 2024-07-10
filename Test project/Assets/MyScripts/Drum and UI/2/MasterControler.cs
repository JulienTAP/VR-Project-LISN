using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterControler : MonoBehaviour
{
    public GameObject drum;
    public GameObject dropdown;
    public GameObject slider;

    public void PosDrum(float value)
    {
        drum.GetComponent<DrumPosition2>().ChangePos(value);
    }

    public void SetDrum(int value)
    {
        drum.GetComponent<DrumPosition2>().SetPos(value);
    }

    public void NotifyFromDropdown()
    {
        switch (dropdown.GetComponent<Dropdown>().value)
        {
            case 0:
                slider.GetComponent<Slider>().value = 0.5f;
                break;
            case 1:
                slider.GetComponent<Slider>().value = 1f;
                break;
            case 2:
                slider.GetComponent<Slider>().value = 0f;
                break;
        }
        this.SetDrum(dropdown.GetComponent<Dropdown>().value);

    }

    public void NotifyFromSlider()
    {
        switch (slider.GetComponent<Slider>().value)
        {
            case 0f:
                dropdown.GetComponent<Dropdown>().value = 2;
                break;
            case 0.5f:
                dropdown.GetComponent<Dropdown>().value = 0;
                break;
            case 1f:
                dropdown.GetComponent<Dropdown>().value = 1;
                break;
        }
        this.PosDrum(slider.GetComponent<Slider>().value);
    }

    public void Reset()
    {
        slider.GetComponent<Slider>().value = 0.5f;
        dropdown.GetComponent<Dropdown>().value = 0;
        this.SetDrum(0);

    }

    
}
