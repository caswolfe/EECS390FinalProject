using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{

    // Label sound effects as they get added.
    // Current index 0 is "ow" for getting hit.
    public AudioClip[] playerSoundEffects;
    private AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
    }

    public void takeDamage(int DamageAmount) {
        if (DamageAmount >= 0) {
            int randomIndex = Random.Range(0,playerSoundEffects.Length);
            audio.clip = playerSoundEffects[randomIndex];
            audio.Play();
        }
        SceneController.Instance.playerHealth -= DamageAmount;
        if (SceneController.Instance.getHealth() <= 0) {
            SceneController.Instance.playerHealth = 0;
            SceneController.Instance.loadLose();
        }
        else if (SceneController.Instance.getHealth() > 100) {
            SceneController.Instance.playerHealth = 100;
        }
    }
}
