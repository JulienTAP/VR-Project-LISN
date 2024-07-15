using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class ToggleForceGrab : MonoBehaviour
{
    public GameObject settingsCanva;
    private Toggle T;
    private void Start()
    {
        settingsCanva.SetActive(true);
        T = GameObject.Find("Force grab toggle").GetComponent<Toggle>();
        settingsCanva.SetActive(false);
    }
    public void ToggleFG()
    {
        this.GetComponent<XRRayInteractor>().useForceGrab = T.isOn;
    }

    public void DisableFG()
    {
        this.GetComponent<XRRayInteractor>().useForceGrab = false;
    }
}
