using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

   private int cherries=0;
   private int gems=0;
    public Text scoreText;
    public Text scoreGem;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Cherry")){
        cherries++;
        scoreText.text =": "+ cherries;
        }
        if(other.gameObject.CompareTag("Gem")){
        gems++;
        scoreGem.text =": "+ gems;
        }
    }
    
   
}
