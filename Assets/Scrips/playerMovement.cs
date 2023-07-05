
using System.Data.Common;
using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Animations;



public class playerMovement : MonoBehaviour
{
    public static float Speed=10f;
    public float jump;
    private float moving=0f;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public Rigidbody2D rb2d;
    public Animator anim;
    public LayerMask jumpableGround;
    public LayerMask whatIsWall;
    public static bool IsGrounded;
    private int jumpCount;
    private int jumpCountMax = 2;
    private float wallSlideSpeed = 1f;
    private int wallDirection;
    private float wallJumpForce = 10f;
    private float lastWallJumpTime;
    public static bool isFacingRight;
    public static bool isWallSliding = false;
    private float distanceToWall = 0.5f;
    public static bool isMoving = false;
    public static bool moveUp = false;
    public static bool isJumping = false;
    public static bool isSlidingLeft = false;
    public static bool isFalling = false;
    [SerializeField] private AudioSource audioSource;
    private bool animActive = false;
    private AnimatorClipInfo[] clipInfo;
    public static Transform player;
    public ParticleController particleController;

    public bool IsWallSliding
    {
        get => isWallSliding; set
        {
            if(value){
                Debug.Log("WallSliding");
            }
            isWallSliding = value;
        }
    }

    void Start()
    {
         rb2d = GetComponent<Rigidbody2D> ();
         coll = GetComponent<BoxCollider2D>();
         sprite = GetComponent<SpriteRenderer> ();
         anim = GetComponent<Animator>();
         isMoving = false;
         moveUp = false; 
         player = GetComponent<Transform>();
     }
    void Update()
    {
        Flip();
        MoveJump();
        // JumpWall();
        WallSlip();
        UpdateAnimationUpdate();
    }
   
   
    public void SetDownMoveUp(){
        if(jumpCount < 2){
            moveUp = true;
        } else {
            moveUp = false;
        }
       
        

    }

    private void MoveJump()
    {

        if(moveUp){
            if(IsWallSliding){
                lastWallJumpTime = Time.time;
                IsWallSliding = false;
                audioSource.Play();
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
                TriggerAnimation("Jump");
                jumpCount++;
                moveUp = false;
                isJumping = true;
                particleController.PlayDustJumpEffect();
            } else{
                audioSource.Play();
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
                TriggerAnimation("Jump");
                jumpCount++;
                moveUp = false;
                isJumping = true;
                particleController.PlayDustJumpEffect();
            }

            
        }
    }

    private void SetTrueWallSliding(){
        // set true wallsliding nếu như nhân vật đang chạm vào tường
    }
    
    public void OnButtonLeftDown(){
        isMoving = true;
        moving = -Speed;
        isFacingRight = false;
      
    }
    public void OnButtonRightDown(){
        isMoving= true;
        moving = Speed;
        isFacingRight = true;
      
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
            if(IsGrounded && !IsWallSliding){
                TriggerAnimation("Run");
            }
        } 
    }
    private void Flip()
    {
        if (moving > 0)
        {
            sprite.flipX = false;
            isSlidingLeft = false;
        }
        else if (moving < 0)
        {
            sprite.flipX = true;
            isSlidingLeft = true;
        }
    }
    void WallSlip(){
        if(IsWallSliding == true && moveUp == false){
            TriggerAnimation("jumpWall");
            if(rb2d.velocity.y < -wallSlideSpeed){
                rb2d.velocity = new Vector2(rb2d.velocity.x, -wallSlideSpeed);
            }
        } else if(IsWallSliding == true && moveUp == true){
            if(Time.time < lastWallJumpTime + 0.2f){
                rb2d.velocity = new Vector2(-wallDirection * wallJumpForce, jump);
            }
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            IsWallSliding = false;
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
    void OnCollisionStay2D(Collision2D collision)
    {
        CheckJumpInWall(collision);
        CheckGrounded(collision);
    }

    private void CheckJumpInWall(Collision2D collision){
        // 
        if(collision.gameObject.tag == "Wall" && !IsWallSliding && rb2d.velocity.y < 0f && !IsGrounded && !moveUp){
            
            IsWallSliding = true;
            TriggerAnimation("jumpWall");
            jumpCount = 0;
           
            
        }
     }
    private void CheckAnimationJumpWall()
    {
        if (IsWallSliding == true)
        {
            
            // TriggerAnimation("jumpWall");  
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
            
            IsWallSliding = true;
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
            isWallSliding = false;
            isJumping = false;
            isFalling = false;
            BoolAnimation("DoubleJump", false);
            
        }       
    }
    private void CheckEnemy(Collision2D collision)
    {
        if (collision.gameObject.tag == "monster" || collision.gameObject.tag == "trap")
        {
            jumpCount = 0;
        }
    }

    private void BoolAnimation(string name, bool value){
      if(animActive == false)
        {
            animActive = true;
            anim.SetBool(name, value);
            resetAnimationActive();
        }

    }

    private void resetAnimationActive()
    {
       animActive = false;

    }

    private void TriggerAnimation(string name){
        if(animActive == false){
            animActive = true;
            anim.SetTrigger(name);
            resetAnimationActive();
        }
    }
    

    void UpdateAnimationUpdate(){
      
  
        // if(isMoving && IsGrounded == true && IsWallSliding == false){
        //     TriggerAnimation("Run");
        // }
        if(!isMoving && IsGrounded == true && IsWallSliding == false){
            BoolAnimation("Idle", true);
        } else {
            BoolAnimation("Idle", false);
        }
        
        if(rb2d.velocity.y< -1f){
            TriggerAnimation("Fall");
            isFalling = true;
        }
        //double jump
        if(jumpCount==2){
            BoolAnimation("DoubleJump", true);
        }else {
            BoolAnimation("DoubleJump", false);
        }
    }
    
    
}


