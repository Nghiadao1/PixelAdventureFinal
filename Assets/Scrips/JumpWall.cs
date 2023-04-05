using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWall : MonoBehaviour
{
   
    private float Speed=7f;
    private float jump=7f;
    private float moveNgang=0f;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public Rigidbody2D rb2d;
    public Animator anim;
    private enum MovementStage {idle,Running,Jumping, Falling, Double_Jump};
    public LayerMask jumpableGround;
    private bool IsGrounded;
    private int jumpCount;
    private bool isWallSliding;
    private float wallSlideSpeed = 0.5f;
    private float wallJumpForce = 10f;
    private float wallStickTime = 0.1f;
    private float lastWallJumpTime;
    private float lastWallStickTime;
    private int wallDirection;
    
   
   
    
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
    moveNgang = Input.GetAxis("Horizontal");
    
    if (isWallSliding)
    {
        anim.SetTrigger("jumpWall");
        // Giữ nhân vật ở tốc độ trượt tường
        rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -wallSlideSpeed, float.MaxValue));
        
        if (Input.GetButtonDown("Jump"))
        {
            // Nhảy từ tường
            Vector2 jumpDirection = new Vector2(-wallDirection, 1f);
            rb2d.velocity = jumpDirection * wallJumpForce;
            isWallSliding = false;
            jumpCount++;
            lastWallJumpTime = Time.time;
        }
        
        if (Time.time > lastWallStickTime + wallStickTime)
        {
            isWallSliding = false;
        }
    }
    else
    {
        // Di chuyển bình thường khi không bám tường
        rb2d.velocity = new Vector2(Speed * moveNgang, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            // Nhảy bình thường
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
            jumpCount++;
        }
        // update animation
        UpdateAnimationUpdate();
    }

    // Kiểm tra xem nhân vật có đang bám tường không
    if (!isWallSliding)
    {
        IsGrounded = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
        if (IsGrounded)
        {
            jumpCount = 0;
        }
    }

    
}
    
  
    void OnCollisionEnter2D(Collision2D col)
{
    if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("trap") || col.gameObject.CompareTag("monster"))
    {
        jumpCount = 0;
    }
    else if (col.gameObject.CompareTag("Wall"))
    {
        isWallSliding = true;
        wallDirection = col.contacts[0].normal.x > 0 ? -1 : 1;
        lastWallStickTime = Time.time;
    }
}

void OnCollisionExit2D(Collision2D col)
{
    if (col.gameObject.CompareTag("Wall"))
    {
        isWallSliding = false;
    }
}

    //Animation
    void UpdateAnimationUpdate(){
        MovementStage stage;
        if(moveNgang>0f){
            stage = MovementStage.Running;
            sprite.flipX = false;
        } else if(moveNgang<0f){
            stage = MovementStage.Running;
             sprite.flipX = true;
        } else {
            stage = MovementStage.idle;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            stage = MovementStage.Jumping;
        } else if(rb2d.velocity.y< -1f){
            stage = MovementStage.Falling;
        }
        if(jumpCount==2){
            stage = MovementStage.Double_Jump;
            if(rb2d.velocity.y< -1f){
                stage = MovementStage.Falling;
            }
        }

        anim.SetInteger("stage",(int)stage);
    }
    

}
