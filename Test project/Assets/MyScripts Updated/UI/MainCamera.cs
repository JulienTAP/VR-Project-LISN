using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MainCamera : MonoBehaviour
{
    private TrackedPoseDriver driver;
    private Vector3 localPosition;
    private Quaternion localRotation;

    private void Start()
    {
        driver = GetComponent<TrackedPoseDriver>();
        localPosition = transform.localPosition;
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
        transform.localPosition = localPosition;
        transform.localRotation = localRotation;
    }
}
