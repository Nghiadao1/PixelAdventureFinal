using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustFallController : MonoBehaviour
{
    public GameObject dustEffectFallLeft;
    public GameObject dustEffectFallRight;
    public bool isFalling;
    // Start is called before the first frame update
    void Start()
    {
        dustEffectFallLeft.SetActive(false);
        dustEffectFallRight.SetActive(false);
        isFalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetFalseFall();
    }
    void SetFalseFall(){
        if(isFalling == true){
            Invoke("invokeFalseFall", 0.3f);
            isFalling = false;
        }
    }
    void invokeFalseFall(){
        dustEffectFallLeft.SetActive(false);
        dustEffectFallRight.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ground") && isFalling == false)
        {
            isFalling = true;
            dustEffectFallLeft.SetActive(true);
            dustEffectFallRight.SetActive(true);
              
    }
}
}
