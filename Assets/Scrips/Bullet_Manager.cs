using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Manager : MonoBehaviour
{
    private Collider2D coll;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject,0.1f);
        }
    }
    
}
