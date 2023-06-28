using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsActiveShield : MonoBehaviour
{
    public GameObject ShieldOfPlayer;

    // Update is called once per frame
    void Update()
    {
        if(Items.isShieldActive == true){
            ShieldOfPlayer.SetActive(true);
        } else if(Items.isShieldActive == false){
            ShieldOfPlayer.SetActive(false);
        }
    }
}
