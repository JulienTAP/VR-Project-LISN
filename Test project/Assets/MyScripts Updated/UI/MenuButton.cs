using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;


public class MenuButton : MonoBehaviour
{
    [HideInInspector]
    public bool IsMenuMode = true;

    public GameObject AdminOverlay;
    public GameObject PositionCanva;
    public GameObject GrabCanva;
    public GameObject ConfirmPlayingCanva;
    public DrumKit1 Drumkit;
    public Xylophone Xylo;
    public Controller LeftController;
    public Controller RightController;
    public MainCamera Camera;
    public DrumSticks LeftStick;
    public DrumSticks RightStick;

    public XROrigin XRRig;

    private bool BlockPosition = false;

    private void Start()
    {
        XRRig.MoveCameraToWorldLocation(new Vector3(0, 2 + 1.2f, 0));
        XRRig.MatchOriginUpCameraForward(new Vector3(0, 1, 0), new Vector3(1, 0, 0));

    }

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
            EnterMenuMode();
        }
        if (BlockPosition)
        {
            XRRig.MoveCameraToWorldLocation(new Vector3(0, 2 + 1.2f, 0));
        }
    }

    public void ConfirmSettings(bool EnterConfirmCanva)
    {
        //Camera.ToggleTracking(!EnterConfirmCanva);
        AdminOverlay.SetActive(!EnterConfirmCanva);
        PositionCanva.SetActive(!EnterConfirmCanva);
        ConfirmPlayingCanva.SetActive(EnterConfirmCanva);
        GrabCanva.SetActive(!EnterConfirmCanva);
        Drumkit.SetDrumsGrabInteractions(!EnterConfirmCanva);
        Xylo.GetComponent<XRGrabInteractable>().enabled = !EnterConfirmCanva;
        LeftStick.GetComponent<XRGrabInteractable>().enabled = !EnterConfirmCanva;
        RightStick.GetComponent<XRGrabInteractable>().enabled = !EnterConfirmCanva;
        IsMenuMode = true;
        BlockPosition = EnterConfirmCanva;
        if (!EnterConfirmCanva)
        {
            XRRig.MoveCameraToWorldLocation(new Vector3(0, 2 + 1.2f, 0));
            XRRig.MatchOriginUpCameraForward(new Vector3(0, 1, 0), new Vector3(1, 0, 0));
        }
    }

    public void EnterPlayMode()
    {
        IsMenuMode = false;
        LeftController.SetXRayInteractor(false);
        RightController.SetXRayInteractor(false);
        ConfirmPlayingCanva.SetActive(false);
        LeftStick.GetComponent<XRGrabInteractable>().enabled = true;
        RightStick.GetComponent<XRGrabInteractable>().enabled = true;
        BlockPosition = false;

        XRRig.MoveCameraToWorldLocation(new Vector3(0, 2 + 1.2f, 0));
        XRRig.MatchOriginUpCameraForward(new Vector3(0,1,0), new Vector3(1,0,0));

    }

    public void EnterMenuMode()
    {
        IsMenuMode = true;
        LeftController.SetXRayInteractor(true);
        RightController.SetXRayInteractor(true);
        LeftStick.GetComponent<XRGrabInteractable>().enabled = true;
        RightStick.GetComponent<XRGrabInteractable>().enabled = true;
        Drumkit.ToggleDrumsGrabInteractions();
        Xylo.ToggleXyloGrabInteractions();
        //Camera.ToggleTracking(true);
        AdminOverlay.SetActive(true);
        PositionCanva.SetActive(true);
        GrabCanva.SetActive(true);
        XRRig.MoveCameraToWorldLocation(new Vector3(0, 2 + 1.2f, 0));
        XRRig.MatchOriginUpCameraForward(new Vector3(0, 1, 0), new Vector3(1, 0, 0));

    }
}
