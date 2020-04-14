using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkAnimationController : MonoBehaviour
{

    public Animator animator;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            animator.SetBool("On", true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            animator.SetBool("On", false);
        }
    }

}
