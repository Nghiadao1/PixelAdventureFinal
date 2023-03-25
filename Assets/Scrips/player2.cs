using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    public float Speed = 7f;
    public float Jump = 7f;
    private float moveNgang= 0f;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spt;
    private enum MovementState{idle,Running,Jumping,Falling};
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spt = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveNgang = Input.GetAxis("Horizontal");
        rb.velocity =new Vector2(moveNgang*Speed, rb.velocity.y);
        if(Input.GetButtonDown("Jump2")){
            rb.velocity =new Vector2(rb.velocity.x, Jump);
        }
        animationn();
    }

    void animationn(){
        MovementState state;
        if(moveNgang>0f){
            state = MovementState.Running;
            spt.flipX= false;
        } else if(moveNgang<0f){
            state= MovementState.Running;
            spt.flipX=true;
        } else{
            state = MovementState.idle;
        }
        if(rb.velocity.y>.1f){
            state= MovementState.Jumping;
        } else if(rb.velocity.y<-.1f){
            state= MovementState.Falling;
        }
        anim.SetInteger("state",(int)state);
    }
}
