using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Start : MonoBehaviour
{
     public void StartButton()
    {
        SceneManager.LoadScene("Level1");
    }
}
