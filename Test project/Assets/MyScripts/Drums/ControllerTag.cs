using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerTag : MonoBehaviour
{
    private DrumSticksTag DSTag;

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("LDrumStick") || other.CompareTag("RDrumStick")){
            other.GetComponent<DrumSticksTag>().HolderTag = this.tag;
        }
    }

    public void OnTriggerExit(Collider other)
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
