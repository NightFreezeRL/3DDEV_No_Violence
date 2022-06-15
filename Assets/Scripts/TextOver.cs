using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOver : MonoBehaviour
{
    public string texts;
    public Text Text;
    void OnTriggerEnter(){
        Text.text = texts;
    }
     void OnTriggerExit(){
        Text.text = "";
    }
 
}
