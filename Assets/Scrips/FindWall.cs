using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWall : MonoBehaviour
{
    
    public Transform wallCheck;
    public LayerMask whatIsWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool isTouchingWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, whatIsWall);
    }
}
