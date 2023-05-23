using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public void SetVolume(float volume){
        audioSource.volume = volume;
    }
    
}
