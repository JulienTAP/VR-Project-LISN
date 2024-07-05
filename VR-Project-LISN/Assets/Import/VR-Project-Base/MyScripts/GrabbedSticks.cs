using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbedSticks : MonoBehaviour
{

    public string ControllerTag;
    public XRRayInteractor LeftController;
    public XRRayInteractor RightController;

    void start(){
    }

    public void sendTag(){
        Debug.Log("Sending tag");
        if(LeftController.isSelectActive && LeftController.selectTarget.tag == "LDrumStick"){
            ControllerTag = "LeftController";
        } else if(RightController.isSelectActive && RightController.selectTarget.tag == "RDrumStick"){
            ControllerTag = "RightController";
        } else {
            ControllerTag = "NoController";
        }
        Debug.Log(ControllerTag);
    }

    // Update is called once per frame
}
