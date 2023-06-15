using System;
using UnityEngine;

public class SaveByPlayerfrebs : MonoBehaviour
{
    public enum DatabaseKey
    {
        HighScore,
        PlayerName,
        GameLevel,
        CountTime,
        CountSpeed,
        CountShield,
        CountHP,
        Money,

        
    }

    // Generic method to save data to PlayerPrefs
    public static void SaveData<T>(DatabaseKey key, T data)
    {
        string keyString = key.ToString();
        string dataString = string.Empty;
        if (typeof(T).IsPrimitive)
        {
            dataString = data.ToString();
        }
        else
        {
            dataString = JsonUtility.ToJson(data);
        }
        PlayerPrefs.SetString(keyString, dataString);
        PlayerPrefs.Save();
        Debug.Log($"Save: {keyString}: {dataString}");
    }
    // Generic method to load data from PlayerPrefs
    public static T LoadData<T>(DatabaseKey key)
    {
        string keyString = key.ToString();
        if (PlayerPrefs.HasKey(keyString))
        {
            string dataString = PlayerPrefs.GetString(keyString);
            Debug.Log($"Load: {keyString}: {dataString}");
            if (typeof(T).IsPrimitive)
            {
                return (T)Convert.ChangeType(dataString, typeof(T));
            }
            else
            {
                return JsonUtility.FromJson<T>(dataString);
            }
        }
        else
        {
            Debug.Log($"Load: {keyString}: default");
            return default(T);
        }
    }
    
    // Example usage
    public static void ExampleUsage()
    {
        // Save high score
        int highScore = 1000;
        SaveData(DatabaseKey.HighScore, highScore);

        // Load high score
        int loadedHighScore = LoadData<int>(DatabaseKey.HighScore);
        Debug.Log("High Score: " + loadedHighScore);

        // Save player name
        string playerName = "John Doe";
        //SaveData(DatabaseKey.PlayerName, playerName);

        // Load player name
        string loadedPlayerName = LoadData<string>(DatabaseKey.PlayerName);
        Debug.Log("Player Name: " + loadedPlayerName);

    }
}
