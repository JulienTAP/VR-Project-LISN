using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActiveState : MonoBehaviour
{
    public void ToggleState(bool state)
    {
        gameObject.SetActive(state);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
