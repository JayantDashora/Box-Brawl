using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOverUIManager : MonoBehaviour
{
    
    // Variables

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI hishscoreText;

    // Update is called once per frame
    void Update(){
        scoreText.text = "YOUR SCORE : " +  GameData.score.ToString();
        hishscoreText.text = "HIGHSCORE : " +  PlayerPrefs.GetInt("HIGHSCORE").ToString();

    }
}
