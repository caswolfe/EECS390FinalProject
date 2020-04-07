using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour
{
    public float accel;
    public float maxSpeed;
    // I suggest playing around with this value. We want to ease the character into motion rather than a rigid feel.

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed),
                                  Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed));

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            // Move Up = Y--, no X change
            rb.AddForce(new Vector2(0, accel), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Move Up = Y++, no X change
            rb.AddForce(new Vector2(0, -accel), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Move Up = Y++, no X change
            rb.AddForce(new Vector2(-accel, 0), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Move Up = Y++, no X change
            rb.AddForce(new Vector2(accel, 0), ForceMode2D.Force);
        }

        // Handling release keys -- while we want to apply a force, we don't want to have momentum. Players should stop on key release
        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.Sleep();
        }

    }   
}
