using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerTag : MonoBehaviour
{
    private DrumSticksTag DSTag;

    void OnTriggerEnter(Collider other){
        Debug.Log("Interactor trigger with " + other.tag);
        if(other.CompareTag("LDrumStick") || other.CompareTag("RDrumStick")){
            Debug.Log("Sending tag");
            other.GetComponent<DrumSticksTag>().HolderTag = this.tag;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<DrumSticksTag>(out DSTag))
        {
            if (this.CompareTag(DSTag.HolderTag))
            {
                other.GetComponent<DrumSticksTag>().HolderTag = "";
            }
        }
    }

}
