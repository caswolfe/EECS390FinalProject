using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update() {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0) {
            movement = new Vector2(0.1f*Random.Range(-1f, 1f), 0.1f*Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }
    }

    void FixedUpdate() {
        rb.AddForce(movement * maxSpeed);
    }

    public void test() {
        Debug.Log("hi");
    }
}
