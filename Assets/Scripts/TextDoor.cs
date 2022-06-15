using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextDoor : MonoBehaviour
{
    OnTouchKey hasTheKey;
    [SerializeField] GameObject gameObject;
    [SerializeField] GameObject gameObject2;
    public string texts;
    public bool hasKey;
    public Text Text;
    void OnTriggerEnter(){
        hasTheKey = gameObject.GetComponent<OnTouchKey>();
        hasKey = hasTheKey.hasKey;
        if(hasKey){
            gameObject2.SetActive(false);
            SceneManager.LoadScene(2);

        }else{
            Text.text = texts;
        }
    }

    void OnTriggerExit(){
        Text.text = "";
    }

}
