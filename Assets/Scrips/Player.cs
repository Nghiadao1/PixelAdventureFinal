using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

[SerializeField]
    Transform root;
    // Start is called before the first frame update
    void Awake()
    {
        root = transform;
        if(SelectedCharacterData.virtual_GuyActive==true){
            root.Find("Vitrual_Guy")?.gameObject?.SetActive(true);
        } else if(SelectedCharacterData.fog_ManActive==true){
            root.Find("Fog_Man")?.gameObject?.SetActive(true);
        } else{
            root.Find("Vitrual_Guy")?.gameObject?.SetActive(true);
        }
        // active game object name Fog_Man
    

        

    }
    

    
}
