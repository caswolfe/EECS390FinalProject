using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : MonoBehaviour
{

    public bool paused;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().takeDamage(10);
            Destroy(gameObject);
        }
    }

    public void Shoot(float bulletTravelTime, float bulletTravelSpeed, float positionX, float positionY) {
        StartCoroutine(coroutineShoot(bulletTravelTime, bulletTravelSpeed, positionX, positionY));
    }

    public IEnumerator coroutineShoot(float bulletTravelTime, float bulletTravelSpeed, float positionX, float positionY) {
        float time = 0;
        while (time < bulletTravelTime) {
            if(!paused) {
                time += Time.deltaTime;
                if (this.gameObject != null) {
                    transform.position += new Vector3(Time.deltaTime * positionX * bulletTravelSpeed, Time.deltaTime * positionY * bulletTravelSpeed, 0);
                }
            }
            yield return null;
        }

        if (this.gameObject != null) {
            Destroy(gameObject);
        }
    }

    public void Pause() {
        paused = true;
    }

    public void Unpause() {
        paused = false;
    }
}
