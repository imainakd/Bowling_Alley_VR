using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class MenuButtons : MonoBehaviour
{

    // public GameObject highMenu;
    void Start(){
        // highMenu.SetActive(false);
    }
    public void BeginGame(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void EndGame(){
        Application.Quit();
    }

    public void showHighScore(){

        SceneManager.LoadScene(2);


    }

    public void showTopScores(){
        SceneManager.LoadScene(3);
    }

}
