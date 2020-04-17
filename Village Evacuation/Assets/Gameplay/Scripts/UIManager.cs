using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Canvas inGameUI;

    public Canvas pauseUI;

    public Canvas optionsUI;

    public Image healthBarIndicator;

    public Text unsavedStudentsNumber;

    public Text levelText;

    private uiState currentState;

    private int maxHealth = 100;

    public enum uiState {
        INGAME,
        PAUSE,
        OPTIONS
    };

    void Start()
    {
        this.setUIState(uiState.INGAME);
    }

    void Update()
    {
        
    }

    public void setUIState(uiState newState){
        switch(newState){
            case uiState.INGAME:
                inGameUI.enabled = true;
                pauseUI.enabled = false;
                optionsUI.enabled = false;
                break;
            case uiState.PAUSE:
                inGameUI.enabled = false;
                pauseUI.enabled = true;
                optionsUI.enabled = false;
                break;
            case uiState.OPTIONS:
                inGameUI.enabled = false;
                pauseUI.enabled = false;
                optionsUI.enabled = true;
                break;
            default:
                this.setUIState(uiState.INGAME);
                break;
        }
    }

    public void updateHealthDisplay(int newHealth){
        
    }

}
