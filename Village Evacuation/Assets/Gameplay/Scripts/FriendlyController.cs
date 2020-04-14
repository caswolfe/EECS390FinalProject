using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyController : MonoBehaviour
{
    [SerializeField] private GameObject controller;

    void Start() {
        controller.GetComponent<SceneController>().updateFriendlies(1);
    }

    public void save() {
        // play audio and animation of save, reduce entities that need to be saved to move on, 
        controller.GetComponent<SceneController>().updateFriendlies(-1);
        Destroy(gameObject);
    }
}
