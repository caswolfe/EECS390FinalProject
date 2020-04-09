﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    public float bulletRotateTime;

    public float bulletTravelTime;

    public float bulletSpawnRate;

    private float time = 0;

    void Start() {
        initBullets(20);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > bulletSpawnRate) {
            initBullets(20);
            time = 0;
        }
    }

    void initBullets(int numBullets) {
        int i;
        for(i = 0; i < numBullets; i++) {
            SpawnBullet();
        }
    }


    void SpawnBullet() {
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.parent=transform;
        b.transform.position = transform.position + new Vector3(2f,0,+0.1f);

        b.transform.RotateAround(transform.position, new Vector3(0, 0, 1f), Random.Range(0f, 360f)); 

        // rotate around boss for bulletRotateTime
        StartCoroutine(RotateForTime(b,Random.Range(-2f, 2f)));
    }

    private IEnumerator RotateForTime(GameObject item, float speed) {
        float time = 0;
        while ( time < bulletRotateTime) {
            time += Time.deltaTime;
            if (item != null) {
                item.transform.RotateAround(transform.position, new Vector3(0, 0, 1f), speed); 
            }
            yield return null;
        }

        // shoot bullets out from center of boss at random speed between 2 and 10
        if (item != null) {
            StartCoroutine(Shoot(item, Random.Range(5f,10f)));
        }
    }

    public IEnumerator Shoot(GameObject item, float bulletTravelSpeed) {
        float time = 0;
        item.transform.parent = null;
        float positionX = item.transform.position.x - transform.position.x;
        float positionY = item.transform.position.y - transform.position.y;
        while (time < bulletTravelTime) {
            time += Time.deltaTime;
            if (item != null) {
                item.transform.position += new Vector3(Time.deltaTime * positionX * bulletTravelSpeed, Time.deltaTime * positionY * bulletTravelSpeed, 0);
            }
            yield return null;
        }

        if (item != null) {
            Destroy(item);
        }
    }
    
    
}
