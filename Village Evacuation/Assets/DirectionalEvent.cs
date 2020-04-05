using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalEvent : MonoBehaviour
{
    private GameObject hitObj;
    private float Distance  = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * 10);
            Debug.DrawLine(transform.position,hit.point, Color.red);
            hitObj = hit.transform.gameObject;
            Distance = Mathf.Abs(hit.point.y - transform.position.y);
            Debug.Log(hitObj.tag + ": " + Distance);
            if (hitObj.tag == "Friendly") {
                Debug.Log("Student was sent home");
                Destroy(hitObj);
            } else if (hitObj.tag == "Enemy") {
                Debug.Log("Covid-19 was killed");
                Destroy(hitObj);
            } else if (hitObj.tag == "Helpful" && Distance <= 0.003) {
                Debug.Log("You washed your hands");
                Destroy(hitObj);
            }
        }
    }
}
