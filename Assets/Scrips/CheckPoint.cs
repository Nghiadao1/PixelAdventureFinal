using System.IO.Enumeration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Animator anim;
    private Collider2D col;
    void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("isActivated", true);
            DameCaculator player = other.GetComponent<DameCaculator>();
            player.spawnPoint = transform.position;
            col.enabled = false;
        }

    }
}
