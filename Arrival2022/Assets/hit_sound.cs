using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hit_sound : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "glass")
        {
            audio.Play();
        }
    }
}
