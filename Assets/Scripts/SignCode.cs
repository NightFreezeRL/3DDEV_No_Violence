using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignCode : MonoBehaviour
{
     [SerializeField] private GameObject sign; 
     [SerializeField] Animator anim1;
     Animator hmm;
     [SerializeField] public bool IsUP = false;
     [SerializeField] public bool Cooldown = false;
     private float waitTime = 3.0f;
     private float SignTime = 3.0f;
     private float timer = 0.0f;
     private float timer2 = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        sign.SetActive(false);
        hmm = anim1.GetComponent<Animator>();
    }
    void Update(){
        if(Cooldown == false){
            if(Input.GetMouseButtonDown(0)){
                if(sign.activeSelf == false){
                    sign.SetActive(true);
                    IsUP = true;
                    anim1.SetBool("Sign", true);
                    Cooldown = true;
                }
            }
        }else{
            timer2 += Time.deltaTime;
            if(timer2 > SignTime){
                IsUP = false;
                anim1.SetBool("Sign", false);           
                sign.SetActive(false);
                timer += Time.deltaTime;
                if(timer > waitTime){
                    timer = 0;
                    timer2 = 0;
                    Cooldown = false;
                }
                
            }
        }
    }

   
}
