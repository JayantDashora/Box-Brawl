using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private void Update() {
        // Updating the score
        scoreText.text = GameData.score.ToString();        
    }

}
