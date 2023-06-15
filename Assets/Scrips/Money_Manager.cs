using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class Money_Manager : MonoBehaviour
{
    // private string savePath = "money.txt";
    public static int moneyCollected = 0;
    public Text moneyText;


    public void AddMoney (int amount) {
        moneyCollected+=amount;
        SaveMoney();
        UpdateWallet();
    }

    // private void Awake()
    // {
    //     DontDestroyOnLoad(gameObject);
    // }

    void Start()
    {
        LoadMoney();
        UpdateWallet();
    }

    public void UpdateWallet()
    {
        moneyText.text = $":{moneyCollected.ToString()}";
    }

    public void SaveMoney()
    {
        // string data = moneyCollected.ToString();
        // File.WriteAllText(savePath, data);
        SaveByPlayerfrebs.SaveData(SaveByPlayerfrebs.DatabaseKey.Money, moneyCollected);
    }

    public static void LoadMoney()
    {
        // if (File.Exists(savePath))
        // {
        //     string data = File.ReadAllText(savePath);
        //     int.TryParse(data, out moneyCollected);
        // }

        moneyCollected = SaveByPlayerfrebs.LoadData<int>(SaveByPlayerfrebs.DatabaseKey.Money);
        
    }

    public void CollectMoney()
    {
        moneyCollected += Score.cherries;
        SaveMoney();
        Debug.Log("Money collected: " + moneyCollected);
    }
}

