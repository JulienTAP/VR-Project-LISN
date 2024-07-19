using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDrumStickReset : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }

    
}
