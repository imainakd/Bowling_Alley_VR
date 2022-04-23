using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void showMainMenu(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void quitGame(){
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
