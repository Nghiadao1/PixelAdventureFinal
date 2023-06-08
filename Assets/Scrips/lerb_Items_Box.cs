using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class lerb_Items_Box : MonoBehaviour
{
    public Button button;
    public int currentWayPoints=0;
    public GameObject startPos;
    public GameObject endPos;
    public static float speed = 2f;
    private bool checkEndPos = false;

    // Start is called before the first frame update
    void Start()
    {
       
    } 
    void Update()
    {
        button.onClick.AddListener(lerpBoxItem);
        //  lerpBoxItem();
    }

    // Update is called once per frame
    public void lerpBoxItem(){
        if(checkEndPos == false){
            transform.position = endPos.transform.position;
            checkEndPos = true;
        } else{
            transform.position =  startPos.transform.position;
            checkEndPos = false;
        }
       
    }
    
}
