using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            health = 0;
        }
    }

    public void takeDamage(int DamageAmount) {
        health -= DamageAmount;
        Debug.Log("Players health: " + health);
    }

    public int getHealth() {
        return health;
    }
}
