using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

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
        // This will keep the camera fixed on the player, but we will need to change it when we want a more dynamic camera. 
        transform.position = player.transform.position + offset;
    }
}
