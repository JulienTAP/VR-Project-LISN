using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UIKeyDown : MonoBehaviour
{
    public GameObject MenuCanva;
    public GameObject RightController;
    private bool InGameMode;

    private void Start()
    {
        this.InGameMode = false;
    }

    private void Update()
    {
        Debug.Log(Input.GetButton("OpenMenu"));
        if (Input.GetButton("OpenMenu")/* && InGameMode*/)
        {
            RightController.GetComponent<XRRayInteractor>().enabled = true;
            MenuCanva.SetActive(true);
        }
    }

    public void ToggleGameMode(bool state)
    {
        this.InGameMode = state;
    }
}
