using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkAnimationController : MonoBehaviour
{

    public Animator animator;

    [SerializeField] private GameObject player;

    private bool used = false;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && !used){
            other.GetComponent<PlayerController>().takeDamage(-10);
            animator.SetBool("On", true);
            used = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            animator.SetBool("On", false);
        }
    }

}
