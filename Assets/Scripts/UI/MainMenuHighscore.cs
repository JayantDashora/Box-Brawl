using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class MainMenuHighscore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highscoreText;
    private void Update() {
        highscoreText.text = "HIGHSCORE : " + PlayerPrefs.GetInt("HIGHSCORE").ToString();
    }
}
