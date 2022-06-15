using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("SampleScene");
    }
    public void goToMenu(){
        SceneManager.LoadScene(0);
    }
    public void ExitGame(){
        Application.Quit();
    }
}
