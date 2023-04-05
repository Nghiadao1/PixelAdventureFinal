using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cherry : MonoBehaviour
{
    private Animator anim;
    
   private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("Player")){
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("collected");
        Invoke("DestroyCherry", 1f);
        
   }
   }
   private void DestroyCherry(){
       Destroy(gameObject);
   }
}
