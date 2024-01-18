using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{

    //Variables

    [SerializeField] private GameObject gameOver;

    // Main menu play button
    public void MainMenuPlayButton(){
        SceneManager.LoadScene("MainGame");
    }

    // Gameover screen home button
    public void GameOverHomeButton(){

        SceneManager.LoadScene("MainMenu");
    }
}
