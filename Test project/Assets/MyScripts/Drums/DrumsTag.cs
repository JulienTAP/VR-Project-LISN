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
    private Vector3 velocity;
    private float magnitude;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LDrumStick") || other.CompareTag("RDrumStick"))
        {
            velocity = other.GetComponent<Rigidbody>().velocity;
            magnitude = velocity.magnitude;
            if(velocity.y < 0 )
            {
                if(magnitude > 1.0f)
                {
                    audioSource.volume = 1.0f;
                }
                else
                {
                    audioSource.volume = velocity.magnitude;
                }
                holderTag = other.GetComponent<DrumSticksTag>().HolderTag;
                if (holderTag == "LeftController")
                {
                    LeftController.SendHapticImpulse(0.5f, 0.1f);
                }
                else if (holderTag == "RightController")
                {
                    RightController.SendHapticImpulse(0.5f, 0.1f);
                }
                audioSource.Play();
            }
            
        }
    }

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    
}
