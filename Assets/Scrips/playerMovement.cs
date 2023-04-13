using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class playerMovement : MonoBehaviour
{
    private float Speed=10f;
    private float jump=14f;
    private float moveNgang=0f;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public Rigidbody2D rb2d;
    public Animator anim;
    public LayerMask jumpableGround;
    public LayerMask whatIsWall;
    private bool IsGrounded;
    private int jumpCount;
    private float wallSlideSpeed = 0.5f;
    private int wallDirection;
    private float wallJumpForce = 10f;
    private float lastWallJumpTime;
    private bool isWallSliding = false;
    private float distanceToWall = 0.5f;
    // ground check
 
    
    // Start is called before the first frame update
    void Start()
    {
         rb2d = GetComponent<Rigidbody2D> ();
         coll = GetComponent<BoxCollider2D>();
         sprite = GetComponent<SpriteRenderer> ();
         anim = GetComponent<Animator>();
     }
    void Update()
    {
        MoveHorizontal();
        Flip();
        MoveJump();
        JumpWall();
        WallSlip();
        UpdateAnimationUpdate();
    }
    private void MoveJump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
            jumpCount++;
        }
    }
    private void MoveHorizontal()
    {
            moveNgang = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveNgang * Speed, rb2d.velocity.y);  
    }
    private void Flip()
    {
        if (moveNgang > 0)
        {
            sprite.flipX = false;
        }
        else if (moveNgang < 0)
        {
            sprite.flipX = true;
        }
    }
    void WallSlip(){
        if(isWallSliding == true){
            if(rb2d.velocity.y < -wallSlideSpeed){
                rb2d.velocity = new Vector2(rb2d.velocity.x, -wallSlideSpeed);
            }
        }
    }
    void JumpWall(){
        if(Input.GetButtonDown("Jump") && isWallSliding){
            rb2d.velocity = new Vector2(wallJumpForce * wallDirection, jump);
            lastWallJumpTime = Time.time;
            isWallSliding = false;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall"){
            isWallSliding = false;
        }
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        CheckGrounded(collision);
        CheckWallSliding(collision);
        CheckEnemy(collision);
        CheckAnimationJumpWall();
    }
    private void CheckAnimationJumpWall()
    {
        if (isWallSliding == true)
        {
            anim.SetTrigger("jumpWall");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * wallDirection, distanceToWall, whatIsWall);
            if (hit.collider != null)
            {
                sprite.flipX = false;
            }
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.left * wallDirection, distanceToWall, whatIsWall);
            if (hit2.collider != null)
            {
                sprite.flipX = false;
            } 
        }
    }
    private void CheckWallSliding(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            
            isWallSliding = true;
            jumpCount = 0;
            wallDirection = collision.gameObject.transform.position.x > transform.position.x ? -1 : 1;
        }
    }

    private void CheckGrounded(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" )

        {
            IsGrounded = true;
            jumpCount = 0;
        }
    }
    private void CheckEnemy(Collision2D collision)
    {
        if (collision.gameObject.tag == "monster" || collision.gameObject.tag == "trap")
        {
            jumpCount = 0;
        }
    }

    void UpdateAnimationUpdate(){
      
  
        if(moveNgang > 0f && IsGrounded == true && isWallSliding == false){
            anim.SetTrigger("Run");
        } else if(moveNgang<0f && IsGrounded == true && isWallSliding == false){
            anim.SetTrigger("Run");
        } else {
            anim.SetTrigger("Idle");
        }
        if(Input.GetButtonDown("Jump") && jumpCount < 2){
            anim.SetTrigger("Jump");
        } 
        else if(rb2d.velocity.y< -1f){
            anim.SetTrigger("Fall");
        }
        //double jump
        if(jumpCount==2){
            anim.SetBool("DoubleJump", true);
            if(rb2d.velocity.y< -1f){
                anim.SetBool("DoubleJump", false);
                anim.SetTrigger("Fall");
            }
        } else {
            anim.SetBool("DoubleJump", false);
        }
      
    }
}    

    

