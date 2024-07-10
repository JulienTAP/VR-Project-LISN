using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerTag : MonoBehaviour
{
    //public DrumSticksTag LeftStick;
    //public DrumSticksTag RightStick;
    //private DrumSticksTag currentStick;
    /*
    public void OnSelectEnter(XRBaseInteractable interactable)
    {
        currentStick = interactable.GetComponent<DrumSticksTag>();
        Debug.Log("ControllerTag: " + this.tag + ", sending to stick");
        currentStick.sendTag(this.tag);
    }
    */
    private DrumSticksTag DSTag;

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("LDrumStick") || other.CompareTag("RDrumStick")){
            Debug.Log("ControllerTag: " + this.tag + ", sending to stick" + other.tag);
            other.GetComponent<DrumSticksTag>().HolderTag = this.tag;
        }
        
        //Debug.Log("ControllerTag: " + this.tag + ", sending to stick :" + currentStick.tag);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<DrumSticksTag>(out DSTag))
        {
            if (this.CompareTag(DSTag.HolderTag))
            {
                Debug.Log("Removing tag");
                other.GetComponent<DrumSticksTag>().HolderTag = "";
            }
        }
    }
}
