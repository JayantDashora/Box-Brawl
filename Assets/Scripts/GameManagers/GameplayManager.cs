using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject uiCanvas;

    private void Start() {
        StartGameSetup();
    }

    // Checking whether the game is over or not
    private void Update() {
        if(GameData.health <= 0){
            GameOver();
            if(GameData.score > PlayerPrefs.GetInt("HIGHSCORE")){
                PlayerPrefs.SetInt("HIGHSCORE",GameData.score);
            }
        }
    }

    // Add gameover logic here
    private void GameOver(){
        uiCanvas.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    // Game start setup
    private void StartGameSetup(){
        GameData.health = 10;
        GameData.score = 0;    

    }

}
