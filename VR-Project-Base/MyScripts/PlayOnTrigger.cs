using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayOnTrigger : MonoBehaviour
{
    private AudioSource source;
    private float volume = 1.0f;
    private float magnitude;
    private Vector3 velocity;
    private XRBaseController usedController;
    private string ControllerTag;
    private XRBaseController LeftController;
    private XRBaseController RightController;
    public float VolumeCoefficient;
    public float MagnitudeThreshold;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LDrumStick" || other.tag == "RDrumStick")
        {
            Debug.Log("Drumstick hit");
            velocity = other.GetComponent<Rigidbody>().velocity;
            //Debug.Log(velocity);
            ControllerTag = other.GetComponent<GrabbedSticks>().ControllerTag;
            Debug.Log(ControllerTag);
            if(ControllerTag=="LeftController"){
                usedController = LeftController;
            } else if(ControllerTag=="RightController"){
                usedController = RightController;
            }
            if(velocity.y < 0 ){
                magnitude = velocity.magnitude;
                if(magnitude * VolumeCoefficient>MagnitudeThreshold){
                    volume = 1.0f;
                } else {
                    volume = magnitude * VolumeCoefficient / MagnitudeThreshold;
                }
                //Debug.Log(volume);
                source.volume = volume;
                usedController.SendHapticImpulse(0.5f, 0.5f);
                Debug.Log("Playing sound");
                source.Play();
            }
        } else if(other.tag == "Player" && source.isPlaying)
        {
            source.Pause();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        LeftController = GameObject.FindWithTag("LeftController").GetComponent<XRController>();
        RightController = GameObject.FindWithTag("RightController").GetComponent<XRController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
