using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerMovement : MonoBehaviour
{
    public static float Speed=10f;
    private float jump=14f;
    private float moving=0f;
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
    private bool isMoving = false;
    private bool moveUp = false;
    
    [SerializeField] private AudioSource audioSource;
    


    // ground check
 
    
    // Start is called before the first frame update
    void Start()
    {
         rb2d = GetComponent<Rigidbody2D> ();
         coll = GetComponent<BoxCollider2D>();
         sprite = GetComponent<SpriteRenderer> ();
         anim = GetComponent<Animator>();
         isMoving = false;
         moveUp = false; 
     }
    void Update()
    {
        Flip();
        MoveJump();
        JumpWall();
        WallSlip();
        UpdateAnimationUpdate();
    }
   
   
    public void SetDownMoveUp(){
        moveUp = true;
    }

    private void MoveJump()
    {
        if (moveUp == true && jumpCount < 2)
        {
            audioSource.Play();
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
            jumpCount++;
            anim.SetTrigger("Jump");
            moveUp = false;
            Debug.Log("Loooxi zum");
        }
        
    }
    
    public void OnButtonLeftDown(){
        isMoving = true;
        moving = -Speed;

    }
    public void OnButtonRightDown(){
        isMoving= true;
        moving = Speed;


    }
    public void OnButtonLeftUp(){
        isMoving = false;
        
    }
    public void OnButtonRightUp(){
        isMoving = false;
    }
    private void FixedUpdate() {
        if(isMoving){
            rb2d.velocity = new Vector2(moving, rb2d.velocity.y);
        } else {
            // nhân vật dừng lại và set animation idle
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }
    private void Flip()
    {
        if (moving > 0)
        {
            sprite.flipX = false;
        }
        else if (moving < 0)
        {
            sprite.flipX = true;
        }
    }
    void WallSlip(){
        if(isWallSliding == true){
            anim.SetTrigger("jumpWall");
            if(rb2d.velocity.y < -wallSlideSpeed){
                rb2d.velocity = new Vector2(rb2d.velocity.x, -wallSlideSpeed);
            }
        }
    }
    void JumpWall(){
        if(moveUp == true && isWallSliding){
            rb2d.velocity = new Vector2(wallJumpForce * wallDirection, jump);
            lastWallJumpTime = Time.time;
            isWallSliding = false;
            anim.SetTrigger("Jump");
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
        CheckJumpInWall(collision);
    }

    private void CheckJumpInWall(Collision2D collision){
        if(collision.gameObject.tag == "Wall" && isMoving ==true){
            isWallSliding = true;
        }
     }
    private void CheckAnimationJumpWall()
    {
        if (isWallSliding == true)
        {
            
            anim.SetTrigger("jumpWall");  
            Debug.Log("jumpWall");
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
            moveUp = false;
            anim.SetBool("DoubleJump", false);
            
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
      
  
        if(isMoving && IsGrounded == true && isWallSliding == false){
            anim.SetTrigger("Run");
            Debug.Log("Run");
        }
        if(!isMoving && IsGrounded == true && isWallSliding == false){
            anim.SetTrigger("Idle");
            Debug.Log("Idle");
        }
        
        if(rb2d.velocity.y< -1f){
            anim.SetTrigger("Fall");
            Debug.Log("Fall");
        }
        //double jump
        if(jumpCount==2){
            anim.SetBool("DoubleJump", true);
            Debug.Log("DoubleJump");
        }else {
            anim.SetBool("DoubleJump", false);
        }
      
    }
    
    
}

