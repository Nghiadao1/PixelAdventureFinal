using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Money_Manager : MonoBehaviour
{
    private string savePath = "money.txt";
    private int moneyCollected = 0;
    public Text moneyText;

    void Start()
    {
        LoadMoney();
    }
    void SaveMoney()
    {
        string data = moneyCollected.ToString();
        File.WriteAllText(savePath, data);
    }

    void LoadMoney()
    {
        if (File.Exists(savePath))
        {
            string data = File.ReadAllText(savePath);
            int.TryParse(data, out moneyCollected);
        }
    }

    // Hàm này được gọi khi người chơi thu thập tiền
    public void CollectMoney()
    {
        moneyCollected += Score.cherries;
        SaveMoney();
        moneyText.text =":"+ moneyCollected.ToString();
        Debug.Log("Money collected: " + moneyCollected);
    }
}

