using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResetPlayerPosition : MonoBehaviour
{
    private Vector3 originalPos;
    private Quaternion originalRot;
    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        originalRot = mainCamera.transform.rotation;
    }

    public void ResetPlayer(){
        transform.position = originalPos;
        mainCamera.transform.rotation = originalRot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
