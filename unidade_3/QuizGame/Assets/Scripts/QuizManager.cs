using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText; // reference to the question text object
    public List<TextMeshProUGUI> answerTexts; // list of references to the answer text objects
    public Button nextButton; // reference to the next button object

    private int currentQuestionIndex; // index of the current question
    private List<Question> questions; // list of questions

    void Start()
    {
        Debug.Log("Iniciei!");
        // load the questions from a data source (e.g. JSON file)
        questions = LoadQuestions();

        // display the first question
        DisplayQuestion(SceneCategory.value);
    }

    void DisplayQuestion(int index)
    {
        // set the question text
        questionText.text = questions[index].question;

        // set the answer texts
        for (int i = 0; i < answerTexts.Count; i++)
        {
            answerTexts[i].text = questions[index].options[i];
        }

        // reset the button selectors
        foreach (ButtonSelector buttonSelector in FindObjectsOfType<ButtonSelector>())
        {
            buttonSelector.SelectAnswer();
        }

        // set the current question index
        currentQuestionIndex = index;
    }

    public void SelectAnswer(int answerIndex)
    {
        // check if the answer is correct
        bool isCorrect = questions[currentQuestionIndex].answer == answerIndex;

        // display feedback to the player
        if (isCorrect)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Incorrect!");
        }

        // move on to the next question or end the quiz
        if (currentQuestionIndex < questions.Count - 1)
        {
            DisplayQuestion(currentQuestionIndex + 1);
        }
        else
        {
            Debug.Log("Quiz complete!");
            nextButton.gameObject.SetActive(false);
        }
    }

    private List<Question> LoadQuestions()
    {
        QuestionLoader questionLoader = FindObjectOfType<QuestionLoader>();
        return questionLoader.GetQuestions(0);
    }
}

// [System.Serializable]
// public class Question
// {
//     public string question; // the question text
//     public List<string> answers; // the answer choices
//     public int correctAnswer; // the index of the correct answer
// }