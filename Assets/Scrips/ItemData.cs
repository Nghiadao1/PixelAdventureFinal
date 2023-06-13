using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemData : MonoBehaviour
{
    public static int countSpeed;
    public static int countTime;
    public static int countShield;
    public static int countHP;
    public Money_Manager saveMoney;
    public Text moneyText;
    public Text countItemNum;
    public Text countItemNum2;
    public Text countItemNum3;
    public Text countItemNum4;

    public void Start()
    {
        LoadDataItems();
        PrintDataItems();
        updateMoney();
    }
    
    public void updateMoney()
    {
        saveMoney.SaveMoney();
        moneyText.text =":"+ Money_Manager.moneyCollected.ToString();
    }
    void LoadDataItems(){
        countSpeed = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountSpeed);
        countTime = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountTime);
        countShield = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountShield);
        countHP = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountHP);
    }
    void PrintDataItems(){
        int time = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountTime);
        countItemNum.text = time.ToString();
        int speed = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountSpeed);
        countItemNum2.text = speed.ToString();
        int hp = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountHP);
        countItemNum3.text = hp.ToString();
        int shield = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.CountShield);
        countItemNum4.text = shield.ToString();
    }
    public void BuyTime(){
        if(Money_Manager.moneyCollected >= 25){
            Money_Manager.moneyCollected -= 25;
            countTime++;
            SaveByPlayerfrebs.SaveData(SaveByPlayerfrebs.DatabaseKey.CountTime, countTime);
            Debug.Log("Time: " + countTime);
            updateMoney();
            countItemNum.text = countTime.ToString();
            
        }
    }
    public void BuySpeed(){
        if(Money_Manager.moneyCollected >= 10){
            Money_Manager.moneyCollected -= 10;
            countSpeed++;
            SaveByPlayerfrebs.SaveData(SaveByPlayerfrebs.DatabaseKey.CountSpeed, countSpeed);
            Debug.Log("Speed: " + countSpeed);
            updateMoney();
            countItemNum2.text = countSpeed.ToString();
        }
    }
  
    public void BuyHP(){
        if(Money_Manager.moneyCollected >= 20){
            Money_Manager.moneyCollected -= 20;
            countHP++;
            SaveByPlayerfrebs.SaveData(SaveByPlayerfrebs.DatabaseKey.CountHP, countHP);
            Debug.Log("HP: " + countHP);
            updateMoney();
            countItemNum3.text = countHP.ToString();

        }
    }
    public void BuyShield(){
        if(Money_Manager.moneyCollected >= 30){
            Money_Manager.moneyCollected -= 30;
            countShield++;
            SaveByPlayerfrebs.SaveData(SaveByPlayerfrebs.DatabaseKey.CountShield, countShield);
            Debug.Log("Shield: " + countShield);
            updateMoney();
            countItemNum4.text = countShield.ToString();
          
        }
    }
  
      
}
