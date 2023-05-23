using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerTakeDameMonter : DameCaculator
{
     private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15);
            anim.SetTrigger("Jump");
        }
    }
}
