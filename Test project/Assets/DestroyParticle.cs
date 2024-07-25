using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void DelayDestroy()
    {
        Invoke(nameof(DestroySelf), 0.5f);
    }

}
