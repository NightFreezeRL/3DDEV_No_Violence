using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchDoor : MonoBehaviour
{
    OnTouchKey hasTheKey;
    [SerializeField] GameObject gameObject;
    public bool hasKey;

    void Awake(){
        hasTheKey = gameObject.GetComponent<OnTouchKey>();
    }

   void OnTriggerEnter(Collider other){
        hasKey = hasTheKey.hasKey;
        if(hasKey){
            hasTheKey.hasWon = true;
            //text ?
        }else{
            //Text appear?
        }
    }
   
}
