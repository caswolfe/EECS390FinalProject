using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour
{
    void Start(){
        
    }

    void Update(){
        
    }

    public void onBack(){
        SceneManager.LoadScene("MainMenu");
    }

}
