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

    private GameObject ParticlesPrefab;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LDrumStick") || other.CompareTag("RDrumStick"))
        {
            velocity = other.GetComponentsInParent<Rigidbody>()[1].velocity;
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
                holderTag = other.GetComponentInParent<DrumSticks>().HolderTag;
                if (holderTag == "LeftController" && LeftController != null)
                {
                    LeftController.SendHapticImpulse(0.1f, 0.1f);
                }
                else if (holderTag == "RightController" && RightController != null)
                {
                    RightController.SendHapticImpulse(0.1f, 0.1f);
                }
                GameObject Particles = Instantiate(ParticlesPrefab, other.transform.position, other.transform.rotation);
                Particles.GetComponent<DestroyParticle>().DelayDestroy();
                audioSource.Play();
            }
            
        }
    }

    void Start(){
        ParticlesPrefab = GameObject.Find("ParticleSystem");
        audioSource = GetComponent<AudioSource>();
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
