using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearShoter : DameCaculator
{
    public static Animator anim2;
    // Start is called before the first frame update
    void Start()
    {
        anim2 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // PearAttack();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
            
            if (other.gameObject.CompareTag("Player"))
            {
                
                anim2.SetTrigger("Pear_Hit");
                Destroy(gameObject, 0.5f);
            }
    }
    private void OnCollisionEnter2D(Collision2D other) {
      
        if(other.gameObject.CompareTag("Player")){
            
            // call message to player active OncolitionEnter2D() from dame caculator
            // other.gameObject.SendMessage("OnCollisionEnter2D", other);
        
        }
       
    }
    void PearAttack()
    {
        if (anim2.GetCurrentAnimatorStateInfo(0).IsName("Pear_Idle"))
        {
            Invoke("SetAnimationPearAttack", 3f);
        }
        if (anim2.GetCurrentAnimatorStateInfo(0).IsName("Pear_Atack"))
        {
            Invoke("SetAnimationPearIdle", 1f);
        }

    }
    void SetAnimationPearAttack(){
        anim2.SetTrigger("Pear_Atack");
    }
    void SetAnimationPearIdle(){
        anim2.SetTrigger("Pear_Idle");
    }
    public GameObject bulletpfb;
    public void CreateBullet()
    {   
        Vector2 pos = new Vector2(transform.position.x-1f, transform.position.y+0.2f);
        var bullet =  Instantiate(bulletpfb, pos, Quaternion.identity);
        bullet.SetActive(true);
        float speed = 3f;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        Destroy(bullet, 3f);
    }
}
