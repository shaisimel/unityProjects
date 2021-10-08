using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int questionAsked = 0;
    int correctAnswers = 0;
    
    public int getCorrectAnswers() {
        return correctAnswers;
    }

    public void increaseCorrectAnswers() {
        correctAnswers++;
    }

    public int getQuestionAsked() {
        return questionAsked;
    }

    public void increaseQuestionsAsked() {
        questionAsked++;
    }

    public int getScore() {
        return Mathf.RoundToInt(correctAnswers / ((float) questionAsked) * 100);
    }
}
