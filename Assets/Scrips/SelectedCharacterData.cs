using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacterData : MonoBehaviour
{
    public static bool virtual_GuyActive = false;
    public static bool fog_ManActive = false;

    public void SetUpVirtualGuy(){
        virtual_GuyActive = true;
        Debug.Log("setup virtual guy");
    }
    public void SetUpFogMan(){
        fog_ManActive = true;
        Debug.Log("setup Fog guy");
    }
    public void SetDownVirtualGuy(){
        virtual_GuyActive = false;
    }
    public void SetDownFogMan(){
        fog_ManActive = false;
        Debug.Log("setdown fog guy");
    }

}
