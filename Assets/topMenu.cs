using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class topMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI topScoreShowUI;
    
    void Start()
    {
        int[] tscores=new int[10];

        for(int i=0;i<10;i++){
        tscores[i]=PlayerPrefs.GetInt($"t{i}");
        }
        Array.Sort(tscores);
        string highScores="";
        for(int i=9;i>=0;i--){
        highScores+=tscores[i].ToString();
        highScores+="\n";
        }
        topScoreShowUI.SetText(highScores);
    }
    // public void showHighScore(){

        
    //     SceneManager.LoadScene(2);

        
    //     // highMenu.SetActive(true);

    // }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void hideTopScore(){
        SceneManager.LoadScene(0);

        // highMenu.SetActive(false);
        
    }
    public void resetLScores(){ 
        for(int i=0;i<10;i++){
        PlayerPrefs.SetInt($"t{i}",0);
        }
        SceneManager.LoadScene(3);
    }
}
