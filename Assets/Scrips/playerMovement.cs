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
    private enum MovementStage {idle,Running,Jumping, Falling};
    public LayerMask jumpableGround;
   
   
    
    // Start is called before the first frame update
    void Start()
    {
         rb2d = GetComponent<Rigidbody2D> ();
         coll = GetComponent<BoxCollider2D>();
         sprite = GetComponent<SpriteRenderer> ();
         anim = GetComponent<Animator>();
     }

    // Update is called once per frame
    void Update() 
    {
        // transform.rotation = Quaternion.identity;

        // float moveThang =  Input.GetAxis("Horizontal");
         moveNgang =  Input.GetAxis("Vertical");
        // transform.Position = Vector2(moveThang*Speed, );
         rb2d.velocity = new Vector2 ( Speed* moveNgang,rb2d.velocity.y);
         
        // Try out this delta time method??
        // rb2d.transform.position += new Vector3(Speed * Time.deltaTime, 0.0f, 0.0f);
         if (Input.GetButtonDown("Jump")&& IsGrounded()){
            // rb2d.AddForce(Vector2.up*jump, ForceMode2D.Impulse);
            rb2d.velocity= new Vector2(0,jump);
        // UpdateRoi();
       
    }
     UpdateAnimationUpdate();
   
    }
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

        if(rb2d.velocity.y > .1f){
            stage = MovementStage.Jumping;
        } else if(rb2d.velocity.y< -.1f){
            stage = MovementStage.Falling;
        }

        anim.SetInteger("stage",(int)stage);
    }
    private bool IsGrounded(){
      return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size, 0f,Vector2.down, .1f, jumpableGround );
    }
    }

