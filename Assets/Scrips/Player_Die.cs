using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Die : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Rigidbody2D rb;
    public float immunityDuration = 1.0f;
    public bool isImmune = false;
    public Slider healthSlider;
    public int HP = 3;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthSlider.maxValue = HP;
        healthSlider.value = HP;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("trap")){
            takeDamage(); 
        }
        if(other.gameObject.CompareTag("monster")){
            takeDamage(); 
        }
       
    }
    void takeDamage(int damage = 1) {
        if(!isImmune){
            HP -= damage;
            healthSlider.value = HP;
            if (HP <= 0)
            {
                Die();
            }
            else
            {
                startImmune();
            }
        }
    }
    void startImmune() {
        isImmune = true;
        Invoke("stopImmune", immunityDuration);
    }
    void stopImmune() {
        isImmune = false;
    }

    private void Die(){
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");  
    }
    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
