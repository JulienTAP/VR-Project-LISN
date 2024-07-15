using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    public void InstantiateNewObject(GameObject go)
    {
        Instantiate(go, this.transform.position+new Vector3(0,0,-0.1f), this.transform.rotation);
    }
}
