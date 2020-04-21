using System.Collections;
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

    [SerializeField] private GameObject player;

    private float time;

    void Start() {
        playerHealth = 100;
        friendlies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 2) {
            Debug.Log("phealth: " + playerHealth + ", firendlies: " + friendlies);
            time = 0;
        }
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
}
