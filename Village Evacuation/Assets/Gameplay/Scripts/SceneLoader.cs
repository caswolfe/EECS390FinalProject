using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string toLoadScene;

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("collided with " + other.tag);
        if(other.tag == "Player" && SceneController.Instance.friendlies == 0){
            SceneManager.LoadScene(toLoadScene);
        }
    }

}
