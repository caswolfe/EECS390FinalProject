using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public string levelName = "FILL LVL NAME";

    public Canvas inGameUI;

    public Canvas pauseUI;

    public Canvas optionsUI;

    public Image healthBarIndicator;

    public Text unsavedStudentsNumber;

    public Text levelText;

    public Slider volumeSlider;

    private uiState currentState;

    private int maxHealth = 100;

    public PlayableCharacter playerCharacter;

    public CameraController cameraController;

    public lookAtCamera looker;

    public enum uiState {
        INGAME,
        PAUSE,
        OPTIONS
    };

    void Start()
    {
        this.setUIState(uiState.INGAME);
        this.levelText.text = levelName;
    }

    void Update()
    {
        if(Input.GetKeyDown("escape")){
            switch(currentState){
                case uiState.INGAME:
                    this.setUIState(uiState.PAUSE);
                    break;
                case uiState.PAUSE:
                    this.setUIState(uiState.INGAME);
                    break;
                case uiState.OPTIONS:
                    this.setUIState(uiState.PAUSE);
                    break;
                default:
                    Debug.LogWarning("currentState undefined in UIManager");
                    break;
            }
        }
    }

    public void setUIState(uiState newState){
        switch(newState){
            case uiState.INGAME:
                inGameUI.enabled = true;
                pauseUI.enabled = false;
                optionsUI.enabled = false;
                Cursor.visible = false;
                playerCharacter.Unpause();
                cameraController.setIsEnabled(true);
                looker.setIsEnabled(true);
                break;
            case uiState.PAUSE:
                inGameUI.enabled = false;
                pauseUI.enabled = true;
                optionsUI.enabled = false;
                Cursor.visible = true;
                playerCharacter.Pause();
                cameraController.setIsEnabled(false);
                looker.setIsEnabled(false);
                break;
            case uiState.OPTIONS:
                inGameUI.enabled = false;
                pauseUI.enabled = false;
                optionsUI.enabled = true;
                Cursor.visible = true;
                playerCharacter.Pause();
                cameraController.setIsEnabled(false);
                looker.setIsEnabled(false);
                break;
            default:
                this.setUIState(uiState.INGAME);
                break;
        }
        this.currentState = newState;
    }

    public void setHealthDisplay(int newHealth){
        float newXScale = ((float) newHealth) / ((float) maxHealth);
        healthBarIndicator.transform.localScale = new Vector3(newXScale, 1.0f, 1.0f);
    }

    public void setUnsavedStudentsCount(int count){
        unsavedStudentsNumber.text = count.ToString();
    }

    public void setLevel(string level){
        levelText.text = level;
    }

    /*
     * Action Events
     */

    public void onResume(){
        this.setUIState(uiState.INGAME);
    }

    public void onOptions(){
        this.setUIState(uiState.OPTIONS);
    }

    public void onMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void onQuitToDesktop(){
        Application.Quit();
    }

    public void onOptionsBack(){
        this.setUIState(uiState.PAUSE);
    }

    public void onVolumeLevelChange(){
        Debug.Log("volume level now " + volumeSlider.value);
    }

}
