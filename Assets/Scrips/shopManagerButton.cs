using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManagerButton : MonoBehaviour
{
    public GameObject obj;
    public GameObject obj2;
    public void ShopCharacer(){
        obj.SetActive(true);
        obj2.SetActive(false); 
    }
    public void ShopItem(){ 
        obj.SetActive(false);
        obj2.SetActive(true);
    }
}

