using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ButtonManager : MonoBehaviour
{
    public GameObject PausePanel;
    public int level;
    void start(){
        PausePanel = GameObject.Find("PausePanel");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Select_Level");
    }
    public void StartLevelButton()
    {
        SceneManager.LoadScene("Level " + level.ToString());
        Score.cherries = 0;
        Score.gemKeys = 0;
        Time.timeScale = 1;
        DameCaculator.HP = DameCaculator.maxHealth;

    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Score.cherries = 0;
        Score.gemKeys = 0;
        Time.timeScale = 1;
    }
    public void PauseGame(){
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
    public void ResumeGame(){
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Information()
    {
        SceneManager.LoadScene("Information");
    }
    public void Rating()
    {
        SceneManager.LoadScene("Rating");
    }
    
}
