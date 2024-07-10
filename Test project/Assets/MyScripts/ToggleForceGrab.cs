using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class ToggleForceGrab : MonoBehaviour
{
    private Toggle T;
    private void Start()
    {
        T = GameObject.FindWithTag("FGToggle").GetComponent<Toggle>();
    }
    public void ToggleFG()
    {
        this.GetComponent<XRRayInteractor>().useForceGrab = T.isOn;
    }
}
