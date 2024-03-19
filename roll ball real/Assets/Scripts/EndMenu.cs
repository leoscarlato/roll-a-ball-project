using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip gameOver;

    public void start(){

        audioSource.clip = gameOver;
        audioSource.Play();

    }

    public void restartGame(){
        SceneManager.LoadScene(1);
    }

    public void exitButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
