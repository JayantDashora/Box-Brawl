using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Color32 startColor;
    [SerializeField] private Color32 endColor;
    float health, maxHealth = 10;
    float lerpSpeed;

    private void Start(){
        health = maxHealth;
    }

    private void Update(){
        health = GameData.health;
        healthText.text = health.ToString();
        if (health > maxHealth) health = maxHealth;
        lerpSpeed = 3f * Time.deltaTime;
        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller(){
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
    }

    void ColorChanger(){
        Color healthColor = Color.Lerp(endColor,startColor, (health / maxHealth));
        healthBar.color = healthColor;
        healthText.color = healthColor;
    }


}