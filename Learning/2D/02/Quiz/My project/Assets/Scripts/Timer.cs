using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowAnswer = 10f;

    public bool loadNextQuestion;
    public float fillFraction;

    public bool isAnsweringQuestion;
    float timerValue;

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();    
    }

    public void resetTimer() {
        timerValue = 0;
    }

    void UpdateTimer() {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion) {
            if(timerValue > 0f) {
                fillFraction = timerValue / timeToCompleteQuestion;
            } else {
                isAnsweringQuestion = false;
                timerValue = timeToShowAnswer;
            }
        } else {
            if(timerValue > 0f) {
                fillFraction = timerValue / timeToShowAnswer;
            } else {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }
}
