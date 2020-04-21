using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    [Header("Components")]
    public Slider volumeSlider;
    public AudioSource[] audioSources;

    void start(){
        this.volumeSlider.SetValueWithoutNotify(SceneController.Instance.volume);
        this.volumeSlider.value = SceneController.Instance.volume;
    }

    public void onPlay(){
        SceneManager.LoadScene("House1");
    }

    public void onCredits(){
        SceneManager.LoadScene("Credits");
    }

    public void onQuit(){
        Application.Quit();
    }

    public void onVolumeLevelChange(){
        // Debug.Log("volume level now " + volumeSlider.value);
        SceneController.Instance.volume = volumeSlider.value;
        this.setVolume(volumeSlider.value);
    }

    public void setVolume(float level){
        foreach (AudioSource audioSource in audioSources){
            audioSource.volume = level;
        }
    }

}
