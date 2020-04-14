using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void onPlay(){
        SceneManager.LoadScene("House1");
    }

    public void onCredits(){
        SceneManager.LoadScene("Credits");
    }

    public void onQuit(){
        Application.Quit();
    }

}
