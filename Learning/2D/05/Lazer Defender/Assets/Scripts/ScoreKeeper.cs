using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore;
    private UIDisplay ui;

    static ScoreKeeper instace;

    private void Awake() {
        ManageSingleton();
        ui = FindObjectOfType<UIDisplay>();
    }

    private void ManageSingleton() {
        if (instace == null) {
            instace = this;
            DontDestroyOnLoad(gameObject);
        } else {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        Reset();
    }

    public int getCurrentScore() {
        return currentScore;
    }

    public void addToScore(int points) {
        currentScore += points;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
        UpdateUi();
    }

    public void Reset() {
        currentScore = 0;
        UpdateUi();
    }

    private void UpdateUi() {
        ui.UpdateScore(currentScore);
    }
}
