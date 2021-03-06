﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance {
        get;
        set;
    }

    void Awake ()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
        volume = 0.25f;
    }

    public int playerHealth;
    public int friendlies;
    public float volume;

    void Start() {
        playerHealth = 100;
        friendlies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /* Obviously just for debug purposes:*/
        if(Input.GetKeyDown("p")){
            SceneManager.LoadScene("Boss Fight");
        }
    }

    public int getHealth() {
        return playerHealth;
    }

    public int getFriendlies() {
        return friendlies;
    }

    public void loadWin() {
        SceneManager.LoadScene("Win");
    }

    public void loadLose() {
        SceneManager.LoadScene("Lose");
    }
}
