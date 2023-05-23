using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : DameCaculator
{

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("trap")){
            // call message to player active OncolitionEnter2D() from dame caculator
            other.gameObject.SendMessage("OnCollisionEnter2D", other);
        }
}
}