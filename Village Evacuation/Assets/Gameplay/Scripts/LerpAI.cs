using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAI : MonoBehaviour
{
    public const float speed = 5f;
    public float radius = 1.0f;

    private Vector3 _center;
    private Vector3 _end;

    // Start is called before the first frame update
    void Start()
    {
        _center = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 original = this.transform.position;

        // Technically possible that any of the end pts picked are not accessible. This would result in the NPC never moving (?) or potentially being stuck...
        if (transform.position == _center)
        {
            // Randomly chooses a point on the circumference of the circle defined by radius and start
            _end = (Vector2) _center +  Random.insideUnitCircle * radius;
            transform.position = Vector3.Lerp(_center, _end, Time.deltaTime * speed);
        }
        // If we reach our target, then define a new target and continue
        else if (transform.position == _end)
        {
            Vector3 temp = (Vector2) _center + Random.insideUnitCircle * radius;
            transform.position = Vector3.Lerp(_end, temp, Time.deltaTime * speed);
            _end = temp;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _end, Time.deltaTime * speed);
        }
        Vector3 difference = this.transform.position - _end;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 270);

    }

}
