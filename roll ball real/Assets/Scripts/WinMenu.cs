using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void restartGame(){
        SceneManager.LoadScene(1);
    }

    public void exitButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
