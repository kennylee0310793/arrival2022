using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class hit_sound : MonoBehaviour
{
    AudioSource audio;
    public int hit_counter = 0 ;
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
            hit_counter++;
            print(hit_counter);
            if (hit_counter >= 3)
                SceneManager.LoadScene("Scene2");
        }
    }
}
