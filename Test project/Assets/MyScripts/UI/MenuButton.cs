using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [HideInInspector]
    public bool IsMenuMode = true;

    public GameObject AdminOverlay;
    public GameObject PositionCanva;
    public GameObject GrabCanva;
    public DrumKit1 Drumkit;
    public Xylophone Xylo;
    public Controller LeftController;
    public Controller RightController;

    public void ToggleMenuMode(bool isOn)
    {
        IsMenuMode = !IsMenuMode;
        AdminOverlay.SetActive(isOn);
        PositionCanva.SetActive(isOn);
        GrabCanva.SetActive(isOn);
        Drumkit.TogglePlayMode(!isOn);
        Xylo.TogglePlayMode(!isOn);
        LeftController.SetXRayInteractor(isOn);
        RightController.SetXRayInteractor(isOn);
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") > 0.9f && !IsMenuMode)
        {
            ToggleMenuMode(true);
        }
    }
}
