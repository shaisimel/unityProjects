using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Slider healthBar;

    public void UpdateScore(int score) {
        scoreText.text = score.ToString("000000000");
    }

    public void updateHealthBar(float health) {
        healthBar.value = health;
    }
}
