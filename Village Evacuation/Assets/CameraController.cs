using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    public float maxOffset;

    // Use this to keep track of the distance between the player and the camera
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update (each frame)
    void LateUpdate()
    {
        // We still want to keep the camera following the player, so we use this to add offset
        transform.position = player.transform.position + offset;

        // Dynamic Elements -- Find the difference between the mouse position and the camera position...
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        transform.position -= transform.position - mousePosition;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, player.transform.position.x - maxOffset, player.transform.position.x + maxOffset),
                                         Mathf.Clamp(transform.position.y, player.transform.position.y - maxOffset, player.transform.position.y + maxOffset),
                                         transform.position.y);
    }
}
