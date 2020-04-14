using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public int playerHealth;
    public int friendlies;

    [SerializeField] private GameObject player;

    private float time;

    void Start() {
        playerHealth = 100;
        friendlies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        updateHealth();
        time += Time.deltaTime;
        if (time >= 2) {
            Debug.Log("phealth: " + playerHealth + ", firendlies: " + friendlies);
            time = 0;
        }
    }

    public void updateHealth() {
        playerHealth = player.GetComponent<PlayerController>().getHealth();
    }
}
