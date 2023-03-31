using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Fruits : MonoBehaviour
{


    private Animator anim;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("collected");

        }
    }
}
