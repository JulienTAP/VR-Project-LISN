using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DirectController : MonoBehaviour
{
    private DrumSticks DSTag;
    public DrumKit1 Drums;
    public Xylophone Xylo;

    void OnTriggerStay(Collider other){
        if(other.CompareTag("LDrumStick") || other.CompareTag("RDrumStick")){
            other.GetComponent<DrumSticks>().HolderTag = this.tag;
        }
    }

    

    private void Start()
    {
        GetComponent<SphereCollider>().enabled = true;
    }

    private void OnEnable()
    {
        Drums.GetController(tag);
        Xylo.GetController(tag);
    }

    private void OnDisable()
    {
        Drums.RemoveController(tag);
        Xylo.RemoveController(tag);
    }

}
