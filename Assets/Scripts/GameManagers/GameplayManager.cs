using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    
    // Checking whether the game is over or not
    private void Update() {
        if(GameData.health < 0){
            GameOver();
        }
    }

    // Add gameover logic here
    private void GameOver(){
        
    }
}
