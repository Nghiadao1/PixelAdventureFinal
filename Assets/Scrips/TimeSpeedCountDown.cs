using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeSpeedCountDown : MonoBehaviour
{
    public float timeBuffSpeed = 5f;
    public static float currentTimeBuffSpeed = 0f;

    public Text SpeedCountDown;
    // public Text ShieldCountDown;

    void Start()
    {
        currentTimeBuffSpeed = timeBuffSpeed;
    }
   
    void Update()
    {
        
        currentTimeBuffSpeed -= 1*Time.deltaTime;
        SpeedCountDown.text = currentTimeBuffSpeed.ToString(": 0/s");
        if (currentTimeBuffSpeed <= 0)
        {
            currentTimeBuffSpeed = 0;
        }
    }
}
