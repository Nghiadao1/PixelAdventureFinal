using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private bool checkOnMusic;
    private bool checkOnSFX;
    [SerializeField] private GameObject X;
    [SerializeField] private GameObject V;

    [SerializeField] private GameObject V_SFX;
    [SerializeField] private GameObject X_SFX;
    
    void Awake()
    {
        // nhận component X cho gameObject X
        X = GameObject.Find("X");
        V = GameObject.Find("V");
        X_SFX = GameObject.Find("X_SFX");
        V_SFX = GameObject.Find("V_SFX");
    }
    

    void Start()
    {
        if(AudioListener.volume == 1){
            X.SetActive(false);
            V.SetActive(true);
        } else if(AudioListener.volume == 0){
            X.SetActive(true);
            V.SetActive(false);
        }
    }
    

    public void AudioCheckMute()
    {
        if (checkOnMusic == true)
        {
            AudioListener.volume = 1;
            checkOnMusic = false;
            X.SetActive(false);
            V.SetActive(true);
            
        }
        else
        {
            AudioListener.volume = 0;
            checkOnMusic = true;
            X.SetActive(true);
            V.SetActive(false);
        }
    }
    public void SFXCheckMute()
    {
        if (checkOnSFX == true)
        {
            AudioListener.volume = 1;
            checkOnSFX = false;
            X_SFX.SetActive(false);
            V_SFX.SetActive(true);
            
            
        }
        else
        {
            AudioListener.volume = 0;
            checkOnSFX = true;
            X_SFX.SetActive(true);
            V_SFX.SetActive(false);
        }
    }
}
