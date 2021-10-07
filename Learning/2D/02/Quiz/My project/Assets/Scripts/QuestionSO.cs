using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class QuestionSO : using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Quiz Question", order = 0)]
public class QuestionSO : ScriptableObject {
    [TextArea(2,6)]
    [SerializeField] private string question = "Enter your question here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnwerIndex = 0;
     
    public string getQuestion(){
        
        return question;
    }

    public int getCorrectAnswerIndex()
    {
        return correctAnwerIndex;
    }

    public string getAnswer(int index)
    {
        return answers[index];
    }
}
