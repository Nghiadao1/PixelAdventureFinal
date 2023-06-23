using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class lerb_Items_Box : MonoBehaviour
{

    public int currentWayPoints=0;
    public GameObject startPos;
    public GameObject endPos;

    public void lerpBoxItem(){
        transform.position = endPos.transform.position;
        RevertPos();
}
    public void RevertPos(){
        GameObject temp = endPos;
        endPos = startPos;
        startPos = temp;
    }
   
}
