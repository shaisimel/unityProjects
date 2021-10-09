using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    QuestionSO currentQuestion;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questionSOs = new List<QuestionSO>();

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    bool hasAnsweredEarly = true;

    [Header("Buttons")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questionSOs.Count;
        progressBar.minValue = 0;
        progressBar.value = 0;
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

    public bool isComplete() {
        return progressBar.value == progressBar.maxValue;
    }
    private void getNextQuestion() {
        if (questionSOs.Count > 0) {
            setButtonsState(true);
            setDefaultButtonSprites();
            getRandomQuestion();
            displayQuestion();
            scoreKeeper.increaseQuestionsAsked();
        }
        
    }

    private void getRandomQuestion() {
        int index = Random.Range(0, questionSOs.Count);
        currentQuestion = questionSOs[index];
        questionSOs.RemoveAt(index);
    }

    private void displayQuestion() {
        questionText.text = currentQuestion.getQuestion();

        for (int i = 0; i < answerButtons.Length; i++) {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.getAnswer(i);
        }
    }

    public void onAnswerSelected(int index) {
        progressBar.value++;
        hasAnsweredEarly = true;
        displayAnswer(index);
        setButtonsState(false);
        timer.resetTimer();
        scoreText.text = "Score: " + scoreKeeper.getScore() + "%";
    }

    private void displayAnswer(int index) {
        if (index == currentQuestion.getCorrectAnswerIndex()) {
            scoreKeeper.increaseCorrectAnswers();
            questionText.text = "You are correct!";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        } else {
            questionText.text = "You are incorrect. The correct answer is\n" + currentQuestion.getAnswer(currentQuestion.getCorrectAnswerIndex());
            answerButtons[currentQuestion.getCorrectAnswerIndex()].GetComponent<Image>().sprite = correctAnswerSprite;
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
