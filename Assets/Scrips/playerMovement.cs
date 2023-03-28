using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
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
         
    // nhay 2 lan
        // IsGrounded = Physics2D.BoxCast(coll.bounds.center,coll.bounds.size, 0f,Vector2.down, .1f, jumpableGround );
        //   if (IsGrounded)
        // {
        //     jumpCount = 0;
        // }

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
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
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
        }

        anim.SetInteger("stage",(int)stage);
    }
}
    // private bool IsGrounded(){
    //   return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size, 0f,Vector2.down, .1f, jumpableGround );
    // }
    

