using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResetConfiguration : MonoBehaviour
{
    private Vector3[] DrumPositions = new Vector3[5];
    private Quaternion[] DrumRotations = new Quaternion[5];
    private Vector3 XyloPosition;
    private Quaternion XyloRotation;

    public DrumKit Drums;
    public Xylophone Xylophone;

    private void Start()
    {
        GetConfiguration();
    }
    public void GetConfiguration()
    {
        for(int i = 0; i < Drums.InstrumentElements.Length; i++)
        {
            if (Drums.InstrumentElements[i].activeSelf)
            {
                DrumPositions[i] = Drums.InstrumentElements[i].transform.position;
                DrumRotations[i] = Drums.InstrumentElements[i].transform.rotation;
            }
        }
        XyloPosition = Xylophone.gameObject.transform.position;
        XyloRotation = Xylophone.gameObject.transform.rotation;
    }

    public void ResetConfig()
    {
        for(int i = 0;i < Drums.InstrumentElements.Length; i++)
        {
            if (Drums.InstrumentElements[i].activeSelf)
            {
                Drums.InstrumentElements[i].transform.position = DrumPositions[i];
                Drums.InstrumentElements[i].transform.rotation = DrumRotations[i];
            }
        }
        Xylophone.gameObject.transform.position = XyloPosition;
        Xylophone.gameObject.transform.rotation = XyloRotation;
    }
}
