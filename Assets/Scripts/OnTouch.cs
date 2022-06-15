using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch : MonoBehaviour
{
    BallLerp ballLerp;
    [SerializeField] GameObject Ball; 
    void Awake(){
        ballLerp = Ball.GetComponent<BallLerp>();
    }
    void OnTriggerExit(Collider other){
        ballLerp.startBall();
    }

   
}
