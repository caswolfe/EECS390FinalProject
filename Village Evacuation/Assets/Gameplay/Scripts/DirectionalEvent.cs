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
            hitObj = hit.transform.gameObject;
            Distance = Mathf.Abs(hit.point.y - transform.position.y);

            if (hitObj.tag == "Friendly") {
                Debug.Log("Student was sent home");
                Destroy(hitObj);
            } else if (hitObj.tag == "Enemy") {
                Debug.Log("Covid-19 was killed");
                Destroy(hitObj);
            } else if (hitObj.tag == "Helpful" && Distance <= 0.003) {
                Debug.Log("You washed your hands");
                Destroy(hitObj);
            } else if (hitObj.tag == "Boss") {
                /* this is how we should deal with enemies and entities getting hit.
                Enemies and NPCs should have a script that has a function that 
                says how to react to a hit and then here all we do is call that function */
                hitObj.GetComponent<BossController>().takeDamage(10); 
            }
        }
    }
}
