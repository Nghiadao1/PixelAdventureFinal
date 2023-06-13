using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BagItemsManager : MonoBehaviour
{
    public Text countItemTime;
    public Text countItemSpeed;
    public Text countItemHP;
    public Text countItemShield;
    public GameObject Speed_Image;
    public GameObject Shield_Image;
    public Slider healthSlider;
    
    void Start()
    {
        LoadDataItems();
        int time = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountTime);
        countItemTime.text = time.ToString();
        int speed = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountSpeed);
        countItemSpeed.text = speed.ToString();
        int hp = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountHP);
        countItemHP.text = hp.ToString();
        int shield = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountShield);
        countItemShield.text = shield.ToString();
    }
    void LoadDataItems()
    {
        ItemData.countSpeed = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountSpeed);
        ItemData.countTime = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountTime);
        ItemData.countShield = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountShield);
        ItemData.countHP = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountHP);
    }
    public void UsingItemTime()
    {
        if(ItemData.countTime > 0){
            ItemData.countTime--;
            //buff time +25s
            TimeDown.currentTime = TimeDown.currentTime + 25f;
        }
        
        SaveByPlayerfrebs.SaveData(SaveByPlayerfrebs.DatabaseKey.CountTime, ItemData.countTime);
        Debug.Log("Time: " + ItemData.countTime);
        countItemTime.text = ItemData.countTime.ToString();
    }
    public void UsingItemSpeed()
    {   
        if(ItemData.countSpeed > 0){
            ItemData.countSpeed--;
            playerMovement.Speed = 15f;
            Speed_Image.SetActive(true);
            StartCoroutine("ResetSpeedBuff");
        }
        SaveByPlayerfrebs.SaveData(SaveByPlayerfrebs.DatabaseKey.CountSpeed, ItemData.countSpeed);
        Debug.Log("Speed: " + ItemData.countSpeed);
        countItemSpeed.text = ItemData.countSpeed.ToString();
    }
    IEnumerator ResetSpeedBuff()
    {
        yield return new WaitForSeconds(5f);
        if(TimeSpeedCountDown.currentTimeBuffSpeed <= 0f){
            playerMovement.Speed = 10f;
            Speed_Image.SetActive(false);
        }
    }
    public void UsingItemHP()
    {
        if(ItemData.countHP > 0 && DameCaculator.HP < DameCaculator.maxHealth){
            ItemData.countHP--;
            DameCaculator.HP += 1;
            healthSlider.value = DameCaculator.HP;
                
        }
        
        SaveByPlayerfrebs.SaveData(SaveByPlayerfrebs.DatabaseKey.CountHP, ItemData.countHP);
        Debug.Log("HP: " + ItemData.countHP);
        countItemHP.text = ItemData.countHP.ToString();
    }
    public void UsingItemShield()
    {
        if(ItemData.countShield > 0){
            ItemData.countShield--;
            StartShield();
            StartCoroutine("StopShield");
        }
        SaveByPlayerfrebs.SaveData(SaveByPlayerfrebs.DatabaseKey.CountShield, ItemData.countShield);
        Debug.Log("Shield: " + ItemData.countShield);
        countItemShield.text = ItemData.countShield.ToString();
    }
    void StartShield(){
        Shield_Image.SetActive(true);
        // ShieldOfPlayer.SetActive(true); 
        DameCaculator.isImmune = true;
        DameCaculator.immunityDuration = 7f;
    }
    private IEnumerator StopShield()
    {
        yield return new WaitForSeconds(7f);
        DameCaculator.isImmune = false;
        DameCaculator.immunityDuration = 0.75f;
        // ShieldOfPlayer.SetActive(false);
        Shield_Image.SetActive(false);
    }
    
    
}
