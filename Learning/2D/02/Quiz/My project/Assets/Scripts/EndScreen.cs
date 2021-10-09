using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void showFinalScore() {
        if (scoreKeeper == null) {
            scoreKeeper = FindObjectOfType<ScoreKeeper>();
        }
        finalScoreText.text = "Congrats!\nYour score is: " + scoreKeeper.getScore() + "%";
    }
}
