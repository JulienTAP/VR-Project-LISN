using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInZone : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clip;
        source.volume = 0.0f;
        source.Play();
        source.Pause();
        source.volume = 1.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.UnPause();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.Pause();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
