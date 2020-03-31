using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private int maxSounds = 1;
    private List<AudioSource> soundsPlaying = new List<AudioSource>();

    public void PlaySound(AudioSource sound){

        int i = 0;
        while(i < soundsPlaying.Count){
            if (soundsPlaying[i].isPlaying){
                i++;
            }
            else{
                soundsPlaying.RemoveAt(i);
            }
        }

        sound.Play();
        soundsPlaying.Add(sound);

        if(soundsPlaying.Count > maxSounds){
            soundsPlaying[0].Stop();
            soundsPlaying.RemoveAt(0);

        }

    }

    
}
