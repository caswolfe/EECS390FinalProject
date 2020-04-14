using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private static int playerHealth;
    private static int friendlies;

    [SerializeField] private GameObject player;

    private float time;

    // Update is called once per frame
    void Update()
    {
        updateHealth();
        time += Time.deltaTime;
        if (time >= 5) {
            Debug.Log("phealth: " + playerHealth + ", firendlies: " + friendlies);
            time = 0;
        }
    }

    public void updateHealth() {
        playerHealth = player.GetComponent<PlayerController>().getHealth();
    }

    public void updateFriendlies(int changeAmount) {
        friendlies += changeAmount; 
    }
}
