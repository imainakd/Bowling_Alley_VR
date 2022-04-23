using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class HIghMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI highScoreShowUI;
    
    void Start()
    {
        int[] hscores=new int[10];

        for(int i=0;i<10;i++){
        hscores[i]=PlayerPrefs.GetInt($"h{i}");
        }
        int a=PlayerPrefs.GetInt("h11");
        string highScores="";
        for(int i=0;i<10;i++){
        highScores+=hscores[i].ToString();
        highScores+="\n";
        }
        highScoreShowUI.SetText(highScores);
    }
    // public void showHighScore(){

        
    //     SceneManager.LoadScene(2);

        
    //     // highMenu.SetActive(true);

    // }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void hideHighScore(){
        SceneManager.LoadScene(0);

        // highMenu.SetActive(false);
        
    }
    public void resetHScores(){ 
        for(int i=0;i<10;i++){
        PlayerPrefs.SetInt($"h{i}",0);
        }
        SceneManager.LoadScene(2);
    }
}
