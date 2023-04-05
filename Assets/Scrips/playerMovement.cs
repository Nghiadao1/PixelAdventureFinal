using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float Speed=10f;
    private float jump=7f;
    private float moveNgang=0f;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public Rigidbody2D rb2d;
    public Animator anim;
    
    public LayerMask jumpableGround;
    private bool IsGrounded;
    private int jumpCount;
    // biến để thực hiện wall jump
    private float wallSlideSpeed = 0.5f;
    private int wallDirection;
    private float wallJumpForce = 10f;
    private float wallStickTime = 0.1f;
    private float lastWallJumpTime;
    private float lastWallStickTime;
    private bool isWallSliding;
    private float wallCheckRadius = 0.2f;
    public Transform wallCheck;
    public LayerMask whatIsWall;

    
   
   
    
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
    
    // di chuyen ngang
         moveNgang =  Input.GetAxis("Horizontal");
         rb2d.velocity = new Vector2 ( Speed* moveNgang,rb2d.velocity.y);

        if (Input.GetButtonDown("Jump") && jumpCount < 2 )
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
            jumpCount++;
        }
    // update animation
        UpdateAnimationUpdate();
    }
  
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "trap" || collision.gameObject.tag == "monster" || collision.gameObject.tag == "Wall")
        
        {
            jumpCount = 0;
        }
    }
 
    //Animation
    void UpdateAnimationUpdate(){
       
        if(moveNgang>0f){
            anim.SetTrigger("run");
            sprite.flipX = false;
        } else if(moveNgang<0f){
            anim.SetTrigger("run");
             sprite.flipX = true;
        } else {
            anim.SetTrigger("idle");
        }
        if(rb2d.velocity.y>1f){
            anim.SetTrigger("jump");
        } else if(rb2d.velocity.y<-1f){
            anim.SetTrigger("fall");
        } else {
            anim.SetTrigger("idle");
        }
        if(jumpCount==2){
            anim.SetTrigger("doubleJump");
            if(rb2d.velocity.y< -1f){
                anim.SetTrigger("fall");
            }
        }

        anim.SetInteger("stage",(int)stage);
    }
    void OnCollisionEnter2D(Collision2D other)
     {
            if (other.gameObject.tag == "Wall")
            {
                anim.SetTrigger("jumpWall");
                // Kiểm tra xem nhân vật đang ở bên trái hay bên phải tường
                wallDirection = other.transform.position.x > transform.position.x ? -1 : 1;
                // Giữ nhân vật ở tốc độ trượt tường
                rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -wallSlideSpeed, float.MaxValue));
                // is wall check
                isWallSliding = true;
                // Thời gian nhân vật ở trạng thái wall stick
                lastWallStickTime = Time.time;


        

            }
     }
        void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.tag == "Wall")
            {
                isWallSliding = true;
            }
        }
        private bool isTouchingWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, whatIsWall);
    }
}
    

