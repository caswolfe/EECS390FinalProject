using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Options")]
    public string levelName = "FILL LVL NAME";

    public bool showUnsavedStudents = true;

    [Space]
    [Header("UI Components")]
    public Canvas inGameUI;

    public Canvas pauseUI;

    public Canvas optionsUI;

    public Image healthBarIndicator;

    public Text unsavedStudentsLabel;

    public Text unsavedStudentsNumber;

    public Text levelText;

    public Slider volumeSlider;

    private uiState currentState;

    [Space]
    [Header("Game Components")]
    public PlayableCharacter playerCharacter;

    public CameraController cameraController;

    public PlayerController playerController;

    public lookAtCamera looker;

    public AudioSource[] audioSources;

    /*
     *  private vars
     */

    private int maxHealth = 100;

    private int lastHealth;

    private int lastFriendlies;

    public enum uiState {
        INGAME,
        PAUSE,
        OPTIONS
    };

    void Start()
    {
        this.setUIState(uiState.INGAME);
        this.levelText.text = levelName;
        lastHealth = maxHealth;
        Debug.Log("starting volume:" + SceneController.Instance.volume);
        this.volumeSlider.SetValueWithoutNotify(SceneController.Instance.volume);
        setVolume(SceneController.Instance.volume);
        if(!this.showUnsavedStudents){
            this.unsavedStudentsLabel.enabled = false;
            this.unsavedStudentsNumber.enabled = false;
        }
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
        if (SceneController.Instance.getHealth() != lastHealth)
        {
            lastHealth = SceneController.Instance.getHealth();
            setHealthDisplay(lastHealth);
        }
        if (SceneController.Instance.getFriendlies() != lastFriendlies)
        {
            lastFriendlies = SceneController.Instance.getFriendlies();
            setUnsavedStudentsCount(lastFriendlies);
        }
    }

    public void setUIState(uiState newState){
        switch(newState){
            case uiState.INGAME:
                inGameUI.enabled = true;
                pauseUI.enabled = false;
                optionsUI.enabled = false;
                // Cursor.visible = false;
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

    public void setVolume(float level){
        foreach (AudioSource audioSource in audioSources){
            audioSource.volume = level;
        }
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
        SceneController.Instance.volume = volumeSlider.value;
        this.setVolume(volumeSlider.value);
    }

}
