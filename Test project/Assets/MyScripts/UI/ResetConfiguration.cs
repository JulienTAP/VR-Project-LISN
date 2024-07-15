using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetConfiguration : MonoBehaviour
{
    //Will hold all instruments elements
    public GameObject[] InstrumentElements = new GameObject[5];

    private Vector3[] Positions = new Vector3[5];
    private Quaternion[] Rotations = new Quaternion[5];

    private void Start()
    {
        GetConfiguration();
    }
    public void GetConfiguration()
    {
        for(int i = 0; i < InstrumentElements.Length; i++)
        {
            if (InstrumentElements[i].activeSelf)
            {
                Positions[i] = InstrumentElements[i].transform.position;
                Rotations[i] = InstrumentElements[i].transform.rotation;
            } else
            {
                Positions[i] = new Vector3(0,0,0);
                Rotations[i] = new Quaternion(0,0,0,0);
            }
        }
    }

    public void ResetConfig()
    {
        for(int i = 0;i < InstrumentElements.Length; i++)
        {
            if (InstrumentElements[i].activeSelf)
            {
                InstrumentElements[i].transform.position = Positions[i];
                InstrumentElements[i].transform.rotation = Rotations[i];
            }
        }
    }
}
