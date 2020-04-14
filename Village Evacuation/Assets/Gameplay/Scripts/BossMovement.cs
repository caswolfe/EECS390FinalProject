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

    // Current vector
    private Vector3 _current;
    private Vector2 _last;
    private int repeat;
    public float speed;

    // Use this for initialization
    void Start () {
        UpdateVector();
        Physics2D.gravity = Vector2.zero;
        repeat = 0;

        //rb = GetComponent<Rigidbody2D> ();
    }

    void Update() {
        if (_last.x == (int)transform.position.x && _last.y == (int)transform.position.y)
        {
            repeat++;
        }
        if (repeat > 200)
        {
            UpdateVector();
            repeat = 0;
        }

        transform.position += maxSpeed * _current * Time.deltaTime;
        /*
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0) {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        } */
        _last = new Vector2((int)transform.position.x, (int)transform.position.y);
    }

    void UpdateVector()
    {
        _current = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0).normalized;
        Debug.Log(_current.ToString());
    }

    void FixedUpdate() {
        //rb.AddForce(movement * maxSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collide.");
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Collide with wall");
            UpdateVector();
        }
    }
}
