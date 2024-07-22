using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Unity.XR.CoreUtils;

public class MainCamera : XROrigin
{
    private TrackedPoseDriver driver;
    private Vector3 localPosition = Vector3.zero;
    private Quaternion localRotation;

    private new void Start()
    {
        driver = GetComponent<TrackedPoseDriver>();
        localRotation = transform.localRotation;
    }

    public void ToggleTracking(bool isOn)
    {
        if (isOn)
        {
            driver.trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;

        } else
        {
            driver.trackingType = TrackedPoseDriver.TrackingType.RotationOnly;
        }
    }

    public void ResetCameraPosition()
    {
        MoveCameraToWorldLocation(localPosition);
        transform.localRotation = localRotation;
    }
}
