using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DirectController : MonoBehaviour
{
    private DrumSticks DSTag;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("LDrumStick") || other.CompareTag("RDrumStick")){
            other.GetComponent<DrumSticks>().HolderTag = this.tag;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<DrumSticks>(out DSTag))
        {
            if (this.CompareTag(DSTag.HolderTag))
            {
                other.GetComponent<DrumSticks>().HolderTag = "";
            }
        }
    }

    private void Start()
    {
        GetComponent<SphereCollider>().enabled = true;
    }

}
