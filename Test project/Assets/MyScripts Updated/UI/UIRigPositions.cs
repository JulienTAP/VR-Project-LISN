using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UIRigPositions : MonoBehaviour
{

    private Vector3 MenuPosition;
    private Quaternion MenuRotation;
    private Vector3 PlayerPosition;
    private Quaternion PlayerRotation;
    private GameObject[] DrumElements;
    private GameObject[] XyloElements;

    public DrumKit1 Drums;
    public Xylophone Xylophone;
    public GameObject TeleportAnchor;
    public Transform Offset;

    private void Start()
    {
        DrumElements = new GameObject[Drums.MaxElementsNumber];
        Drums.InstrumentElements.CopyTo(DrumElements, 0);
        XyloElements = new GameObject[Xylophone.MaxElementsNumber];
        Xylophone.InstrumentTiles.CopyTo(XyloElements, 0);
        InitPosRX();
    }

    public void InitPosRX()
    {
        MenuPosition = this.transform.localPosition;
        MenuRotation = this.transform.rotation;

        PlayerPosition = TeleportAnchor.transform.position;
        PlayerRotation = TeleportAnchor.transform.rotation;
    }

    public void GoToMenuPosition()
    {
        this.transform.localPosition = MenuPosition;
        Offset.localPosition = new Vector3(0, 1.4f, 0);
    }

    public void GoToPlayerPosition() { 
        this.transform.position = PlayerPosition;
        Offset.localPosition = new Vector3(0, 1, 0);
    }

    public void DisableGrabInteractions()
    {
        foreach(GameObject el in DrumElements)
        {
            el.GetComponent<XRGrabInteractable>().enabled = false;
        }
        Xylophone.GetComponent<XRGrabInteractable>().enabled = false;
    }

    public void EnterPlayerMode()
    {
        GameObject.Find("Left Ray Interactor").GetComponentInChildren<XRRayInteractor>().enabled = false;
        GameObject.Find("Right Ray Interactor").GetComponentInChildren<XRRayInteractor>().enabled = false;
        DisableGrabInteractions();
        GoToPlayerPosition();
    }

}
