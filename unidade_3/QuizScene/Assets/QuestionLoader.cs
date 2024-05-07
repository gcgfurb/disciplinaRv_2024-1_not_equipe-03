using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string question; // the question text
    public List<string> answers; // the answer choices
    public int correctAnswer; // the index of the correct answer
}

[System.Serializable]
public class QuestionData
{
    public List<Question> questions; // the list of questions
}

public class QuestionLoader : MonoBehaviour
{
    public TextAsset questionDataFile; // the JSON file containing the questions

    private QuestionData questionData; // the loaded question data

    void Start()
    {
        // load the question data from the JSON file
        questionData = JsonUtility.FromJson<QuestionData>(questionDataFile.text);
    }

    public List<Question> GetQuestions()
    {
        return questionData.questions;
    }
}
