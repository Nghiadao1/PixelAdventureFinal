using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPlayer : MonoBehaviour
{
    //set up list players
    
    public Transform Players;
    void Start()
    {
        // set up gameobject player by tab
        Players = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //set up camera follow player
      
            transform.position = new Vector3(Players.position.x, Players.position.y, transform.position.z);

    }
}
