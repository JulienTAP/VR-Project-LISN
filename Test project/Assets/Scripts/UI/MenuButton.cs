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
    public DrumKit Drumkit;
    public Xylophone Xylo;
    public Controller LeftController;
    public Controller RightController;
    public MainCamera Camera;
    public DrumSticks LeftStick;
    public DrumSticks RightStick;

    public XROrigin XRRig;

    private void Start()
    {
        Invoke(nameof(EnterMenuMode),1);
    }

    public void ToggleMenuMode(bool isOn)
    {
        IsMenuMode = isOn;
        AdminOverlay.SetActive(isOn);
        PositionCanva.SetActive(isOn);
        GrabCanva.SetActive(isOn);
        LeftController.SetXRayInteractor(isOn);
        RightController.SetXRayInteractor(isOn);
        XRRig.MoveCameraToWorldLocation(new Vector3(0, 2 + 1.2f, 0));
        XRRig.MatchOriginUpCameraForward(new Vector3(0, 1, 0), new Vector3(1, 0, 0));
        if (isOn)
        {
            Xylo.ToggleXyloGrabInteractions();
            Drumkit.ToggleDrumsGrabInteractions();
        } else
        {
            Xylo.GetComponent<XRGrabInteractable>().enabled = false;
            Drumkit.SetDrumsGrabInteractions(false);
        }
    }

    private void EnterMenuMode()
    {
        ToggleMenuMode(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button6) && !IsMenuMode)
        {
            ToggleMenuMode(true);
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            XRRig.MoveCameraToWorldLocation(new Vector3(0, 2 + 1.2f, 0));
            XRRig.MatchOriginUpCameraForward(new Vector3(0, 1, 0), new Vector3(1, 0, 0));
        }
    }

    public void ConfirmSettings(bool EnterConfirmCanva)
    {
        AdminOverlay.SetActive(!EnterConfirmCanva);
        PositionCanva.SetActive(!EnterConfirmCanva);
        ConfirmPlayingCanva.SetActive(EnterConfirmCanva);
        GrabCanva.SetActive(!EnterConfirmCanva);
        Drumkit.SetDrumsGrabInteractions(!EnterConfirmCanva);
        Xylo.GetComponent<XRGrabInteractable>().enabled = !EnterConfirmCanva;
        LeftStick.GetComponent<XRGrabInteractable>().enabled = !EnterConfirmCanva;
        RightStick.GetComponent<XRGrabInteractable>().enabled = !EnterConfirmCanva;
        IsMenuMode = true;
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

        XRRig.MoveCameraToWorldLocation(new Vector3(0, 2 + 1.2f, 0));
        XRRig.MatchOriginUpCameraForward(new Vector3(0,1,0), new Vector3(1,0,0));

    }
}