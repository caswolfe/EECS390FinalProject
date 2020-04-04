using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalEvent : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Input.mousePosition - Input.mousePosition);
    }
}
