using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchKey : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] GameObject door1;
    [SerializeField] GameObject door2;
    [SerializeField] GameObject door3;
    [SerializeField] GameObject door4;
    [SerializeField] GameObject door5;
    [SerializeField] GameObject door6;

    public bool hasKey= false;
    public bool hasWon;
    void OnTriggerEnter(Collider other){
            gameObject.SetActive(false);
            hasKey = true;

            door1.SetActive(false);
            door2.SetActive(false);
            door3.SetActive(false);
            door4.SetActive(false);
            door5.SetActive(false);
            door6.SetActive(false);
            //Text ?
    }
   
}
