using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cherry : MonoBehaviour
{
    private Animator anim;
    private int cherries=0;
    public Text CherryText;
    
   private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("Cherry")){
        
        // Destroy(other.gameObject);
        cherries++;
        CherryText.text =": "+ cherries;
    }
   }
}
