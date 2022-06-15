using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLerp : MonoBehaviour
{
 
    [SerializeField] private GameObject destination; 
    [SerializeField] private GameObject origin; 
    private Vector3 endPosition;
    private Vector3 startPosition;
    private float duration = 2f;
    private float elapsedTime;
    private bool checkerHalf = false;
    private bool checkerWasHalf = false;

    [SerializeField] 
    private AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        startPosition =origin.transform.position;
        endPosition = destination.transform.position;
       
    }
    public void startBall(){
         StartCoroutine(Coroutine(destination));
    }
    IEnumerator Coroutine(GameObject destination){
        while (Vector3.Distance(origin.transform.position, destination.transform.position) > 0.05f){
            elapsedTime += Time.deltaTime;
            float percentComp = elapsedTime /duration;
            transform.position = Vector3.Lerp(startPosition,endPosition,curve.Evaluate(percentComp));
            transform.Rotate(Vector3.left, 100 * Time.deltaTime);
            if(percentComp >= 0.5 && checkerWasHalf == false){
               checkerHalf = true;
               checkerWasHalf = true;
            }
            if(checkerHalf == true && checkerWasHalf == true){
                yield return new WaitForSeconds(3f);
                checkerHalf = false;
            }
            yield return null;
        }
    }
}
