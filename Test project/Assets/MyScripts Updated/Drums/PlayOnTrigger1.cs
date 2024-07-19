using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayOnTrigger1 : MonoBehaviour
{
    private AudioSource audioSource;
    private ActionBasedController LeftController;
    private ActionBasedController RightController;
    private string holderTag;
    private Vector3 velocity;
    private float magnitude;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LDrumStick") || other.CompareTag("RDrumStick"))
        {
            print("Trigger");
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
                if (holderTag == "LeftController")
                {
                    LeftController.SendHapticImpulse(0.5f, 0.1f);
                }
                else if (holderTag == "RightController")
                {
                    RightController.SendHapticImpulse(0.5f, 0.1f);
                }
                print("playing");
                audioSource.Play();
            }
            
        }
    }

    void Start(){
        audioSource = GetComponent<AudioSource>();
        //LeftController = GameObject.FindWithTag("Left Controller").GetComponent<ActionBasedController>();
        //RightController = GameObject.Find("Right Controller").GetComponent<ActionBasedController>();

        foreach(GameObject el in GameObject.FindGameObjectsWithTag("LeftController"))
        {
            el.TryGetComponent<ActionBasedController>(out LeftController);
        }

        foreach (GameObject el in GameObject.FindGameObjectsWithTag("RightController"))
        {
            el.TryGetComponent<ActionBasedController>(out RightController);
        }
    }

}
