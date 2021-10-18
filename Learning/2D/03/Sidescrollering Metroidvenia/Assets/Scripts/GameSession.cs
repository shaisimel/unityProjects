using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int scorePerCoin = 100;
    int coinsCollected = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        if (FindObjectsOfType<GameSession>().Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        livesText.text = playerLives.ToString();
        scoreText.text = getScore().ToString();
    }

    private int getScore() {
        return (coinsCollected * scorePerCoin);
    }

    public void processPlayerDeath() {
        if(playerLives > 1) {
            TakeLife();
        } else {
            ResetGameSession();
        }
    }

    private void TakeLife() {
        playerLives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        livesText.text = playerLives.ToString();
    }

    private void ResetGameSession() {
        SceneManager.LoadScene(0);
        Destroy(FindObjectOfType<ScenePersist>().gameObject);
        Destroy(gameObject);

    }

    public void pickupCoin() {
        coinsCollected++;
        scoreText.text = getScore().ToString();
    }
}
