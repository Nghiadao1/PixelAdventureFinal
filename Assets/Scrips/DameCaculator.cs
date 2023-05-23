using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DameCaculator : MonoBehaviour
{
    [SerializeField]
    public Animator anim;
    public Rigidbody2D rb;
    public static float immunityDuration = 0.75f;
    public static bool isImmune = false;
    public Slider healthSlider;
    public static int HP = 3;
    public static int maxHealth = 3;
    public Vector3 spawnPoint;
    [SerializeField] private AudioSource audioHitSource;
    [SerializeField] private AudioSource audioDeathSource;
    [SerializeField] private AudioSource audioJumpSource;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthSlider = GameObject.Find("HPSlider").GetComponent<Slider>();
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("monster"))
        {
            takeDamage();
        }
        if (other.gameObject.CompareTag("trap"))
        {
            takeDamage();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("monster"))
        {
            audioJumpSource.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15);
            anim.SetTrigger("Jump");
        }
        
    }
    public void takeDamage(int damage = 1) {
        audioHitSource.Play();
        anim.SetTrigger("Hit");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15);
        if(!isImmune){
            startImmune();
            HP -= damage;
            healthSlider.value = HP;
            if (HP <= 0)
            {
                Die();
            }
           
        } else
            {
                startImmune();
            }
    }
    void startImmune() {
        isImmune = true;
        Invoke("stopImmune", immunityDuration);
    }
    void stopImmune() {
        isImmune = false;
    }

    public void Die(){
        Invoke("RestartLevel", 0.3f);
        anim.SetTrigger("Death");
        audioDeathSource.Play();
    }
    private void RestartLevel(){
        transform.position = spawnPoint;
        HP = 3;
        healthSlider.value = HP;
        anim.SetTrigger("Fall");
    }
    
}
