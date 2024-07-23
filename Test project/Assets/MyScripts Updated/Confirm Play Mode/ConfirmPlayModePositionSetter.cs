using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class ConfirmPlayModePositionSetter : MonoBehaviour
{
    public XROrigin XRrig;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        XRrig.MoveCameraToWorldLocation(new Vector3(0, 2 + 1.2f, 0));
       /* XRrig.MatchOriginUpCameraForward(new Vector3(0,1,0), new Vector3(1,0,0));*/
    }
}
