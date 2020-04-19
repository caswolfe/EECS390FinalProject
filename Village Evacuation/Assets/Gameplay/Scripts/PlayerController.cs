using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void takeDamage(int DamageAmount) {
        if (SceneController.Instance.getHealth() > 0) {
            SceneController.Instance.playerHealth -= DamageAmount;
        }
        else {
            SceneController.Instance.playerHealth = 0;
        }
        
        if (SceneController.Instance.getHealth() >= 100) {
            SceneController.Instance.playerHealth = 100;
        }
    }
}
