using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeDown : MonoBehaviour
{
    public static float currentTime = 0f;
    public float startingTime = 120f;
    public Text countdownText;
    public GameObject TimeOutPanel;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString(":0/s");
        if (currentTime <= 0)
        {
            currentTime = 0;
            CheckTimeOutPanel();
        }
    }
    void CheckTimeOutPanel(){
        if(currentTime <= 0){
            TimeOutPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if (CheckOnclickButtonRestartLevel()){
            Time.timeScale = 1;
            RestartLevel();
        }
    }

    bool CheckOnclickButtonRestartLevel(){
        if(Input.GetMouseButtonDown(0) && TimeOutPanel.activeSelf == true){
            return true;
        }
        return false;
    }
     void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

