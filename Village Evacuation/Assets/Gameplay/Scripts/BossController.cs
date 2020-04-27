using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private GameObject renderer;

    private Color damageableColor = new Color(0.75f, 1, 0);

    [SerializeField] int health;

    private static int round = 1;

    void Start() {
        health = 30;
    }

    // Update is called once per frame
    void Update()
    {
        // update should do a health check like this and react accordingly
        if (health <= 0) {
            if (round < 4) {
                for (int i = 0; i < 2; i++) {
                    GameObject b = Instantiate(bossPrefab) as GameObject;    
                    foreach(Transform child in b.transform)
                    {
                        if (child.gameObject.tag == "BossBullet") {
                            Destroy(child.gameObject);
                        }
                    }
                }
            } else {
                GameObject enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = new Vector3(transform.position.x,transform.position.y,0);
            }
            Destroy(gameObject);
            round++;
        }
        if (this.gameObject.GetComponent<BossAttack>().isDamageable()) {
            renderer.GetComponent<SpriteRenderer>().color = damageableColor;
        } else {
            renderer.GetComponent<SpriteRenderer>().color = new Color(1,1,1);
        }

        if (round >= 8) {
            SceneController.Instance.loadWin();
        }
    }

    public void takeDamage(int DamageAmount) {
        if (this.gameObject.GetComponent<BossAttack>().isDamageable()) {
            health -= DamageAmount;
        }

        Debug.Log("Boss health: " + health);
    }

    public void Pause() {
        gameObject.GetComponent<BossAttack>().enabled = false;
        gameObject.GetComponent<BossAttack>().Pause();
        gameObject.GetComponent<BossMovement>().enabled = false;
    }

    public void Unpause() {
        gameObject.GetComponent<BossAttack>().enabled = true;
        gameObject.GetComponent<BossAttack>().Unpause();
        gameObject.GetComponent<BossMovement>().enabled = true;
    }
}
