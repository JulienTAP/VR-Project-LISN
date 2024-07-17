using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RigPositions : MonoBehaviour
{

    private Vector3 MenuPosition = new(0, 0, -2);
    private Vector3 PlayerPosition = Vector3.zero;
    private GameObject[] DrumElements;
    private GameObject[] XyloElements;

    public DrumKit Drums;
    public XylophoneInitializer Xylophone;

    private void Start()
    {
        DrumElements = new GameObject[Drums.MaxElementsNumber];
        Drums.InstrumentElements.CopyTo(DrumElements, 0);
        XyloElements = new GameObject[Xylophone.MaxElementsNumber];
        Xylophone.InstrumentTiles.CopyTo(XyloElements, 0);
    }

    public void GoToMenuPosition()
    {
        this.transform.position = MenuPosition;
    }

    public void GoToPlayerPosition() { 
        this.transform.position = this.PlayerPosition;
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
