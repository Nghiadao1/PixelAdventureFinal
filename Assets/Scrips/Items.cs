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
    public GameObject ShieldOfPlayer;
    public Animator anim;
    public GameObject GamObject;
    public GameObject Speed_Image;
    public GameObject Shield_Image;
   
    void Update()
    {
        if(ShieldOfPlayer.activeSelf == true){
            // SetShieldPosition();
        }
        
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
            StartCoroutine("ResetSpeedBuff");
        }
    }
    IEnumerator ResetSpeedBuff()
    {
        yield return new WaitForSeconds(5f);
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
            StartCoroutine("StopShield");

        }
    }
    void StartShield(){
        Shield_Image.SetActive(true);
        ShieldOfPlayer.SetActive(true); 
        DameCaculator.isImmune = true;
        DameCaculator.immunityDuration = 7f;
    }
    
    private IEnumerator StopShield()
    {
        yield return new WaitForSeconds(7f);
        DameCaculator.isImmune = false;
        DameCaculator.immunityDuration = 0.75f;
        ShieldOfPlayer.SetActive(false);
        Shield_Image.SetActive(false);
    }

    // void SetShieldPosition(){
    //     ShieldOfPlayer.transform.position = Player.player.transform.position;
    // }
}
