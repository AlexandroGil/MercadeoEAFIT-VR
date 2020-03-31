using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    
    
    public AudioSource clip;
    public AudioManager audioManager;

    void OnTriggerEnter(Collider other){

        if (other.tag == "MainCamera"){

            audioManager.PlaySound(this.clip);
            
        }
        
    }

    void OnTriggerExit(Collider other){

        clip.Stop();

    }
}
