using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

   public static int cherries=0;
   public static int gemKeys=0;
    public  Text scoreText;
    public  Text scoreGem;
    [SerializeField] private AudioSource audioSource;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Cherry")){
        cherries++;
        scoreText.text =":"+ cherries;
        audioSource.Play();
        // reset cherries to 0 when restart the level
        
        }
        if(other.gameObject.CompareTag("Gem")){
        gemKeys++;
        scoreGem.text =":"+ gemKeys;
        audioSource.Play();
        // reset gemKeys to 0 when exit the level

        }
    } 
}

