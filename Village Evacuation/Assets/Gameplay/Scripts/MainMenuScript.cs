using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    [Header("Components")]
    public Button optionsButton;
    public Text volumeText;
    public Slider volumeSlider;
    public AudioSource[] audioSources;

    void start(){
        Debug.Log("starting volume (main menu) :" + SceneController.Instance.volume);
        this.optionsButton.interactable = true;
        this.volumeSlider.SetValueWithoutNotify(SceneController.Instance.volume);
        this.volumeText.gameObject.SetActive(false);
        this.volumeSlider.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Debug.Log("PrintOnEnable: script was enabled");
        start();
    }

    void OnSceneLoad(){
        Debug.Log("OnSceneLoaded");
        start();
    }

    public void onPlay(){
        SceneManager.LoadScene("House1");
    }

    public void onOptions(){
        this.optionsButton.gameObject.SetActive(false);
        this.volumeText.gameObject.SetActive(true);
        this.volumeSlider.gameObject.SetActive(true);
    }

    public void onCredits(){
        SceneManager.LoadScene("Credits");
    }

    public void onQuit(){
        Application.Quit();
    }

    public void onVolumeLevelChange(){
        Debug.Log("volume level now " + volumeSlider.value);
        SceneController.Instance.volume = volumeSlider.value;
        this.setVolume(volumeSlider.value);
    }

    public void setVolume(float level){
        foreach (AudioSource audioSource in audioSources){
            audioSource.volume = level;
        }
    }

    public void onMouseExitVolumeSlider(){
        this.optionsButton.gameObject.SetActive(true);
        this.volumeText.gameObject.SetActive(false);
        this.volumeSlider.gameObject.SetActive(false);
    }

}
