using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform1 : MonoBehaviour
{
    public GameObject[] waypoints;
    public int CurrentWaypoints=0; 
    private float speed = 2f;
  
    
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
        if (other.gameObject.tag == "Player"){
            other.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(null);
    }
}
