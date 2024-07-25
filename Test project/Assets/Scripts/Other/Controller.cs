using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Controller : MonoBehaviour
{
    public void SetXRayInteractor(bool isOn){
        GetComponent<XRRayInteractor>().enabled = isOn;
    }
}
