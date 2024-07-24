using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayOnTrigger1 : MonoBehaviour
{
    private AudioSource audioSource;
    private XRDirectInteractor LeftController;
    private XRDirectInteractor RightController;
    private string holderTag;
    private Vector3 velocity;
    private float magnitude;
    private ParticleSystem LeftParticleSystem;
    private ParticleSystem RightParticleSystem;


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
                holderTag = other.GetComponent<DrumSticks>().HolderTag;
                if (holderTag == "LeftController" && LeftController != null)
                {
                    LeftController.SendHapticImpulse(0.1f, 0.1f);
                    
                }
                else if (holderTag == "RightController" && RightController != null)
                {
                    RightController.SendHapticImpulse(0.1f, 0.1f);
                }
                if (other.CompareTag("LDrumStick"))
                {
                    LeftParticleSystem.Play();
                }
                else
                {
                    RightParticleSystem.Play();
                }
                audioSource.Play();
            }
            
        }
    }

    void Start(){
        
        audioSource = GetComponent<AudioSource>();
        LeftParticleSystem = GameObject.Find("LeftDrumStick").GetComponentInChildren<ParticleSystem>();
        RightParticleSystem = GameObject.Find("RightDrumStick").GetComponentInChildren<ParticleSystem>();
    }

    public void GetController(string tag)
    {
        if(tag == "LeftController")
        {
            LeftController = GameObject.FindWithTag(tag).GetComponent<XRDirectInteractor>();

        } else
        {
            RightController = GameObject.FindWithTag(tag).GetComponent<XRDirectInteractor>();
        }
    }

    public void RemoveController(string tag) { 
        if(tag == "LeftController")
        {
            LeftController = null;
        } else
        {
            RightController = null;
        }
    }

}
