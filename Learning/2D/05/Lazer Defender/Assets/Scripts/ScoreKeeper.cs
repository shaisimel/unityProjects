using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore;
    private UIDisplay ui;

    private void Awake() {
        ui = FindObjectOfType<UIDisplay>();
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
