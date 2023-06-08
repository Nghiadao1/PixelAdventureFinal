using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Monster : MonoBehaviour
{

    public GameObject[] wayPoints;
    public int currentWayPoints=0; 
    public static float speed = 2f;
    private SpriteRenderer sprite;
    // private Collider2D col;

    private void Start(){
      
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
     transform.position = Vector2.MoveTowards(transform.position, 
     wayPoints[currentWayPoints].transform.position, speed * Time.deltaTime);
    }

   private void OnTriggerEnter2D(Collider2D other) {
    
    if(other.gameObject.CompareTag("Player")){

        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("monsterDie");
        Destroy(gameObject, 0.5f);
    }
    }
    

}

