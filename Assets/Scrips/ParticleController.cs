
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class ParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dustEffectRight; 
    public GameObject dustEffectLeft;
    public GameObject dustEffectSlidingLeft;
    public GameObject dustEffectSlidingRight;
    public GameObject dustEffectJump;
    public GameObject GroundCheck;
    public GameObject dustEffectFallLeft;
    public GameObject dustEffectFallRight;
    void Start()
    {
        dustEffectLeft.SetActive(false);
        dustEffectRight.SetActive(false);
        dustEffectSlidingLeft.SetActive(false);
        dustEffectSlidingRight.SetActive(false);
    }
    void Update()
    {
        PlayDustRun();
        EnableDustRun();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ground")){
            PlayDustRun();
        }
        if(other.gameObject.CompareTag("Wall")){
            CheckSlidingLeft();
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Wall")){
            dustEffectSlidingLeft.SetActive(false);
            dustEffectSlidingRight.SetActive(false);
        }
    }
    //Run
    void EnableDustRun()
    {
        if(playerMovement.isMoving == false){
            dustEffectLeft.SetActive(false);
            dustEffectRight.SetActive(false);
        }
    }
    public void PlayDustRun(){
        if(playerMovement.isMoving == true && playerMovement.IsGrounded == true 
        && playerMovement.isWallSliding == false )
        {
            if(playerMovement.isFacingRight == false){
                dustEffectLeft.SetActive(true);
                dustEffectRight.SetActive(false);
            } else{
                dustEffectLeft.SetActive(false);
                dustEffectRight.SetActive(true);
            }

        }
        
    }
    //Jump
    public void CreateSmokeEffect(Vector3 position)
    {
        GameObject dustJumpEffect = Instantiate(dustEffectJump, position, Quaternion.identity);
        Destroy(dustJumpEffect, 0.3f);
    }
    public void PlayDustJumpEffect()
    {
        CreateSmokeEffect(GroundCheck.transform.position);
       
    }
    //Sliding
    void CheckSlidingLeft(){
        if(playerMovement.isSlidingLeft == true){
            dustEffectSlidingLeft.SetActive(true);
            dustEffectSlidingRight.SetActive(false);
        } else {
            dustEffectSlidingLeft.SetActive(false);
            dustEffectSlidingRight.SetActive(true);
        }
    }
}
