using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 500;
    }

    // Update is called once per frame
    void Update()
    {

        /* update should do a health check like this and react accordingly
        if (health <= 0) {
            Debug.Log("YOU WIN BOSS IS AT 0 HEALTH");
        } else if (health <= 250) {
            Debug.Log("")
        }
        */
    }

    public void takeDamage(int DamageAmount) {
        health -= DamageAmount;
        Debug.Log("Boss health: " + health);
    }
}
