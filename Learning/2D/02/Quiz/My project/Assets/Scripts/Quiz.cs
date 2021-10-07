using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    bool hasAnsweredEarly;

    [Header("Buttons")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        getNextQuestion();
    }

    private void Update() {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion) {
            hasAnsweredEarly = false;
            getNextQuestion();
            timer.loadNextQuestion = false;
        } else if (!hasAnsweredEarly && !timer.isAnsweringQuestion) {
            displayAnswer(-1);
            setButtonsState(false);
        }
    }

    private void getNextQuestion() {
        setButtonsState(true);
        setDefaultButtonSprites();
        displayQuestion();
    }

    private void displayQuestion() {
        questionText.text = question.getQuestion();

        for (int i = 0; i < answerButtons.Length; i++) {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.getAnswer(i);
        }
    }

    public void onAnswerSelected(int index) {
        hasAnsweredEarly = true;
        displayAnswer(index);
        setButtonsState(false);
        timer.resetTimer();
    }

    private void displayAnswer(int index) {
        if (index == question.getCorrectAnswerIndex()) {
            questionText.text = "You are correct!";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        } else {
            questionText.text = "You are incorrect. The correct answer is\n" + question.getAnswer(question.getCorrectAnswerIndex());
            answerButtons[question.getCorrectAnswerIndex()].GetComponent<Image>().sprite = correctAnswerSprite;
        }
    }

    private void setButtonsState(bool isActive) {
        foreach (GameObject button in answerButtons) {
            button.GetComponent<Button>().interactable = isActive;
        }
    }

    private void setDefaultButtonSprites() {
        foreach(GameObject button in answerButtons) {
            button.GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }
}
