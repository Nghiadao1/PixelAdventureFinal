using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public GameObject[] waypoints;
    public int CurrentWaypoints=0; 
    private float speed = 3f;
    private Animator anim;
    private Rigidbody2D rb;
    public GameObject go;
    // private Collider2D col;

    private void Start(){
        go = GetComponent<GameObject>();
    }
    
    private void Update()
    {
        if (Vector2.Distance(transform.position, waypoints[CurrentWaypoints].transform.position)<.1f)
        {
            CurrentWaypoints++;
            if (CurrentWaypoints >= waypoints.Length)
            {
                CurrentWaypoints = 0;
            }
       
    }
     transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentWaypoints].transform.position, speed * Time.deltaTime);
    }

   private void OnTriggerEnter2D(Collider2D other) {
        // go.SetActive(!go.activeSelf);
       
        Destroy(gameObject);
        // RockDie();   
    }
//     private void OnCollisionEnter2D(Collision2D other)
//     {
        
//         Die();
  
// }
// private void RockDie(){
       
//         anim.SetTrigger("RockDie");
//     }

}

