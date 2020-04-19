using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCamera : MonoBehaviour
{

    private bool isEnabled;

    void Start() {
        isEnabled = true;
    }

    void Update()
    {
        if(isEnabled){
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    public void setIsEnabled(bool b){
        isEnabled = b;
    }

}
