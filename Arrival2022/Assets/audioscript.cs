using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioscript : MonoBehaviour
{
    AudioSource myAudio ;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.PlayDelayed(15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
