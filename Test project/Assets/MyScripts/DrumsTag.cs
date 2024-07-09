using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrumTag : MonoBehaviour
{
    private AudioSource audioSource;
    public XRBaseController LeftController;
    public XRBaseController RightController;
    private string holderTag;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Drums hit");
        //if (other.tag == "LDrumStick" || other.tag == "RDrumStick")
        if(other.CompareTag("LDrumStick") || other.CompareTag("RDrumStick"))
        {
            Debug.Log("Drumstick hit");
            holderTag = other.GetComponent<DrumSticksTag>().HolderTag;
            Debug.Log("Controller tag :" + holderTag);
            if(holderTag=="LeftController"){
                LeftController.SendHapticImpulse(0.5f, 0.1f);
            } else if(holderTag=="RightController"){
                RightController.SendHapticImpulse(0.5f, 0.1f);
            }
                
                audioSource.Play();
        }
    }

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    
}
