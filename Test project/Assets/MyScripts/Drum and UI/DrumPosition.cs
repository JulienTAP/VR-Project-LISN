using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrumPosition : MonoBehaviour
{

    public GameObject Drum;
    private Vector3 PosC;
    private Vector3 PosD;
    private Vector3 PosG;


    void Start() 
    {
        PosC = Drum.transform.position;
        PosD = Drum.transform.position + new Vector3(-1, 0, 0);
        PosG = Drum.transform.position + new Vector3(1, 0, 0);
        
    }

    public void posDrum()
    {
        Debug.Log(this.GetComponent<Dropdown>().value);
        if (this.GetComponent<Dropdown>().value == 0)
        {
            Drum.transform.position = PosC;
        }
        else if (this.GetComponent<Dropdown>().value == 1)
        {
            Drum.transform.position = PosD;
        }
        else if(this.GetComponent<Dropdown>().value == 2)
        {
            Drum.transform.position = PosG;
        }
    }
    
    
}
