using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    int coinsCollected = 0;
    void Awake()
    {
        if (FindObjectsOfType<GameSession>().Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
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
    }

    private void ResetGameSession() {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void pickupCoin() {
        coinsCollected++;
    }
}
