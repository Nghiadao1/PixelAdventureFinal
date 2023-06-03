using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettextInShop : MonoBehaviour
{
    [SerializeField] private Text selectedText;
    [SerializeField] private Text selectedText2;
    [SerializeField] private Button button;

    // Update is called once per frame
    void Update()
    {
        if(SelectedCharacterData.virtual_GuyActive == true){
            selectedText.text = "selected";
            button.GetComponentInChildren<Text>().text = selectedText.text;
        } else {
            selectedText.text = "select";
            button.GetComponentInChildren<Text>().text = selectedText.text;
        }
        if(SelectedCharacterData.fog_ManActive == true){
            selectedText2.text = "selected";
            button.GetComponentInChildren<Text>().text = selectedText.text;
        } else {
            selectedText2.text = "select";
            button.GetComponentInChildren<Text>().text = selectedText.text;
        }
    }
}
