using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterControler : MonoBehaviour
{
    public GameObject[] Drums = new GameObject[5];
    public GameObject dropdown;
    public GameObject slider;
    public GameObject xrRig;
    public GameObject Anchor;
    /*public enum DirectionFacing
    {
        X,
        Z
    }
    public enum SideFacing
    {
        Plus,
        Minus
    }
    public SideFacing Side;
    public DirectionFacing Direction;*/
    private int nbDrum = 1;

    public void Start()
    {
        for (int i = 0; i < Drums.Length; i++)
        {
            this.Drums[i].GetComponent<DrumPosition2>().InitPos(i+1);
        }
        xrRig.GetComponent<UIRigPositions>().InitPosRX();

    }


    /*public Vector3 GetVector3(DirectionFacing direction, SideFacing side)
    {

        switch (direction)
        {
            case DirectionFacing.X:
                switch (side)
                {
                    case SideFacing.Plus:
                        return new Vector3(0, 0, -1);
                    case SideFacing.Minus:
                        return new Vector3(0, 0, 1);
                }
                break;
            case DirectionFacing.Z:
                switch (side)
                {
                    case SideFacing.Plus:
                        return new Vector3(1, 0, 0);
                    case SideFacing.Minus:
                        return new Vector3(-1, 0, 0);
                }
                break;

        }
        Debug.Log("Mauvaise direction ou Sens");
        return new Vector3(0, 0, 0);
    }*/

    public void PosDrum(float value/*, Vector3 direction*/)
    {
        for(int i=0; i<Drums.Length; i++)
        {
            this.Drums[i].GetComponent<DrumPosition2>().ChangePos(value/*, direction*/);
        }
        
    }

    public void SetDrum(int value)
    {
        
        for (int i = 0; i < Drums.Length; i++)
        {
            this.Drums[i].GetComponent<DrumPosition2>().SetPos(value/*, GetVector3(Direction, Side)*/);
        }
    }

    public void NotifyFromDropdown()
    {
        switch (this.dropdown.GetComponent<Dropdown>().value)
        {
            case 0:
                this.slider.GetComponent<Slider>().value = 0.5f;
                break;
            case 1:
                this.slider.GetComponent<Slider>().value = 1f;
                break;
            case 2:
                this.slider.GetComponent<Slider>().value = 0f;
                break;
        }
        this.SetDrum(this.dropdown.GetComponent<Dropdown>().value);

    }

    public void NotifyFromSlider()
    {
        switch (this.slider.GetComponent<Slider>().value)
        {
            case 0f:
                this.dropdown.GetComponent<Dropdown>().value = 2;
                break;
            case 0.5f:
                this.dropdown.GetComponent<Dropdown>().value = 0;
                break;
            case 1f:
                this.dropdown.GetComponent<Dropdown>().value = 1;
                break;
        }
        this.PosDrum(this.slider.GetComponent<Slider>().value/*, this.GetVector3(Direction,Side)*/);
    }

    public void Reset()
    {
        this.slider.GetComponent<Slider>().value = 0.5f;
        this.dropdown.GetComponent<Dropdown>().value = 0;
        this.SetDrum(0);

    }

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

    
}
