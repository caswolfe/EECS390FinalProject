using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{

    // Label sound effects as they get added.
    // Current index 0 is "ow" for getting hit.
    public AudioClip[] soundEffects;

    public void takeDamage(int DamageAmount) {
        SceneController.Instance.playerHealth -= DamageAmount;
        if (SceneController.Instance.getHealth() < 0) {
            SceneController.Instance.playerHealth = 0;
        }
        else if (SceneController.Instance.getHealth() > 100) {
            SceneController.Instance.playerHealth = 100;
        }
    }
}
