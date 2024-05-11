using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string question; // the question text
    public List<string> options; // the options choices
    public int answer; // the index of the correct answer
}

[System.Serializable]
public class QuestionData
{   

    public string name;
    public List<Question> questions; // the list of questions
}

public class QuestionLoader : MonoBehaviour
{
    public TextAsset questionDataFile = Resources.Load("Resources/Perguntas_Quizz.json") as TextAsset; // the JSON file containing the questions

    private List<QuestionData> questionData; // the loaded question data

    void Start()
    {
        // load the question data from the JSON file
        questionData = JsonUtility.FromJson<List<QuestionData>>(questionDataFile.text);
    }

    public List<Question> GetQuestions(int idx)
    {
        return questionData[idx].questions;
    }
}
