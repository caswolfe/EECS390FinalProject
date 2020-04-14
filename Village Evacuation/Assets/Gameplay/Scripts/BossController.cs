using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] int health;

    private static int round = 1;

    private bool done = false;

    void Start() {
        health = 30;
    }

    // Update is called once per frame
    void Update()
    {

        // update should do a health check like this and react accordingly
        if (health <= 0) {    
            foreach (GameObject child in transform) {
                Destroy(child);
            }
            if (round < 4) {
                for (int i = 0; i < 2; i++) {
                    GameObject b = Instantiate(bossPrefab) as GameObject;
                    b.transform.localScale = transform.localScale / (transform.localScale.x / 2);
                }
            } else {
                GameObject enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = new Vector3(transform.position.x,transform.position.y,0);
            }
            Destroy(gameObject);
            round++;
        }
    }

    public void takeDamage(int DamageAmount) {
        health -= DamageAmount;
        Debug.Log("Boss health: " + health);
    }
}
