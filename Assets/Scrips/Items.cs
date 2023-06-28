using System.Net.Mime;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Items : MonoBehaviour
{  
    public Slider healthSlider;

    public Animator anim;
    public GameObject GamObject;
    public GameObject Speed_Image;
    public GameObject Shield_Image;
    public static bool isShieldActive = false;
   
    // void Update()
    // {
    //     if(ShieldOfPlayer.activeSelf == true){
    //         SetShieldPosition();
    //     }
        
    // }
    private void Update() {
        ResetSpeedBuff();
        StopShield();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CheckSpeedBuff(other);
        CheckHealthBuff(other);
        CheckTimeBuff(other);
        CheckShieldBuff(other);
    }

    void CheckSpeedBuff(Collider2D other){
        if (other.gameObject.tag == "Player" && this.GamObject.tag == "SpeedBuff"){
            playerMovement.Speed = 15f;
            anim.SetTrigger("collected");
            Speed_Image.SetActive(true);
            Destroy(gameObject, 5.1f);
            
        }
    }
    void ResetSpeedBuff()
    {
        // yield return new WaitForSeconds(TimeSpeedCountDown.currentTimeBuffSpeed);
        CheckTimeBuffSpeed();

    }

    void CheckTimeBuffSpeed(){
        if(TimeSpeedCountDown.currentTimeBuffSpeed <= 0f){
            playerMovement.Speed = 10f;
            Speed_Image.SetActive(false);
        }
    }

    void CheckHealthBuff(Collider2D other){
        if (other.gameObject.tag == "Player" && GamObject.tag == "HealthBuff"){
            if(DameCaculator.HP < DameCaculator.maxHealth) {
                DameCaculator.HP += 1;
                healthSlider.value = DameCaculator.HP;
                
            }
            anim.SetTrigger("collected");
            Destroy(gameObject, 1f);
        }
    }

    void CheckTimeBuff(Collider2D other){
        if (other.gameObject.tag == "Player" && GamObject.tag == "TimeBuff"){
            Destroy(gameObject, 1f);
            TimeDown.currentTime = TimeDown.currentTime + 25f;
            anim.SetTrigger("collected");
        }
    }
    void CheckShieldBuff(Collider2D other){
        if (other.gameObject.tag == "Player" && GamObject.tag == "ShieldBuff"){
            anim.SetTrigger("collected");
            Destroy(gameObject, 7.1f);
            StartShield();

        }
    }
    void StartShield(){
        Shield_Image.SetActive(true);
        DameCaculator.isImmune = true;
        DameCaculator.immunityDuration = 7f;
        isShieldActive = true;
    }
    
     void StopShield()
    {
        // yield return new WaitForSeconds(TimeShieldCountDown.currentTimeBuffShield);
        if(TimeShieldCountDown.currentTimeBuffShield <= 0f){
            DameCaculator.isImmune = false;
            DameCaculator.immunityDuration = 0.75f;
            // ShieldOfPlayer.SetActive(false);
            Shield_Image.SetActive(false);
            isShieldActive = false;
        }
       
    }

    // void SetShieldPosition(){
    //     ShieldOfPlayer.transform.position = Player..transform.position;
    // }
}
