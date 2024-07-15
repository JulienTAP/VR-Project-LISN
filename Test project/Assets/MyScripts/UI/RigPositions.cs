using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RigPositions : MonoBehaviour
{

    public GameObject TeleportAnchor;
    private Vector3 MenuPosition;
    private Quaternion MenuRotation;
    private Vector3 PlayerPosition;
    private Quaternion PlayerRotation;

    public void InitPosRX()
    {
        MenuPosition = this.transform.position;
        MenuRotation = this.transform.rotation;

        PlayerPosition = TeleportAnchor.transform.position;
        PlayerRotation = TeleportAnchor.transform.rotation;
    }

    public void GoToMenuPosition()
    {
        this.transform.position = this.MenuPosition;
        this.transform.rotation = this.MenuRotation;
    }

    public void GoToPlayerPosition() { 
        this.transform.position = this.PlayerPosition;
        this.transform.rotation = this.PlayerRotation;
    }
    public void EnterPlayerMode()
    {
        GameObject.Find("Left Ray Interactor").GetComponentInChildren<XRRayInteractor>().enabled = false;
        GameObject.Find("Right Ray Interactor").GetComponentInChildren<XRRayInteractor>().enabled = false;
        GoToPlayerPosition();
    }

}
