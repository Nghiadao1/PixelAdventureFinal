using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeShieldCountDown : MonoBehaviour
{
    public float timeBuffShield = 7f;
    public static float currentTimeBuffShield = 0f;

    public Text ShieldCountDown;

    void Start()
    {
        currentTimeBuffShield = timeBuffShield;
    }
   
    void Update()
    {
        
        currentTimeBuffShield -= 1*Time.deltaTime;
        ShieldCountDown.text = currentTimeBuffShield.ToString(": 0/s");
        if (currentTimeBuffShield <= 0)
        {
            currentTimeBuffShield = 0;
        }
    }
}
