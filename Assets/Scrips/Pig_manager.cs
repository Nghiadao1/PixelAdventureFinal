using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pig_manager : MonoBehaviour
{
    private int PigHP = 2; 
    private float speed = 2f;
    private float angrySpeed = 4f;
    private bool isAngry = false;
    public Animator anim3;
    public GameObject[] wayPoints;
    public int currentWayPoints=0;
    private SpriteRenderer sprite;
    
    private void Start() {
        isAngry = false;
        anim3 = GetComponent<Animator>();
        PigHP = 2;
        sprite = GetComponent<SpriteRenderer>();
    }
     private void Update()
    {
        if (Vector2.Distance(transform.position, wayPoints[currentWayPoints].transform.position)<.1f)
        {
            currentWayPoints++;
            sprite.flipX = true;
            if (currentWayPoints >= wayPoints.Length)
            {
                currentWayPoints = 0;
                sprite.flipX = false;
            }
       
    }
     transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWayPoints].transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            isAngry = true;
            speed = angrySpeed;
            PigHP -= 1;
            anim3.SetTrigger("hit1");
            if(PigHP <= 0){
                anim3.SetTrigger("hit2");
                Destroy(gameObject, 0.5f);
            }
        }
    }

}
