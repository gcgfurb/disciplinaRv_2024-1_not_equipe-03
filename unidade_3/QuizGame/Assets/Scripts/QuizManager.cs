using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    private TextMeshProUGUI questionText; // reference to the question text object
    private List<TextMeshProUGUI> optionsTexts = new(); // list of references to the option text objects
    private string[] letters = { "A) ", "B) ", "C) ", "D) " };

    private List<Question> questions; // list of questions

    private Question currentQuestion;

    private int corrects;

    private int inCorrects;

    private int indexCurrentQuestion;


    void Start()
    {
        Debug.Log("Iniciei!");
        SetQuestionText();
        SetOptions();
        // load the questions from a data source (e.g. JSON file)
        questions = LoadQuestions();

        // display the first question
        DisplayQuestion();
    }

    void SetQuestionText()
    {
        GameObject textMeshProObject = GameObject.Find("pergunta");
        if (textMeshProObject == null)
        {
            Debug.LogError("GameObject 'pergunta' not found!");
            return;
        }

        questionText = textMeshProObject.GetComponent<TextMeshProUGUI>();
    }

    void SetOptions()
    {
        GameObject textMeshProObject;
        string gameObjectName;
        for (int i = 1; i <= 4; i++)
        {
            gameObjectName = string.Format("opcao{0}", i);
            textMeshProObject = GameObject.Find(gameObjectName);
            if (textMeshProObject == null)
            {
                Debug.LogError(string.Format("GameObject '{0}' not found!", gameObjectName));
                continue;
            }

            optionsTexts.Add(textMeshProObject.GetComponent<TextMeshProUGUI>());
        }
    }

    void DisplayQuestion()
    {
        Random random = new Random();
        indexCurrentQuestion = random.Next(0, questions.Count);
        // Load the random question
        currentQuestion = questions[indexCurrentQuestion];

        // set the question text
        questionText.text = currentQuestion.question;

        // set the answer texts
        for (int i = 0; i < currentQuestion.options.Count; i++)
        {
            optionsTexts[i].text = letters[i] + currentQuestion.options[i];
        }

        // reset the button selectors
        foreach (ButtonSelector buttonSelector in FindObjectsOfType<ButtonSelector>())
        {
            buttonSelector.SelectAnswer();
        }
    }

    public void SelectAnswer(int answerIndex)
    {
        if (questions.Count == 0)
        {
            SceneManager.LoadScene("LobbyScene");
            return;
        }

        // check if the answer is correct
        bool isCorrect = currentQuestion.answer == answerIndex;

        // display feedback to the player
        if (isCorrect)
        {
            corrects++;
            Debug.Log("Correct!");
        }
        else
        {
            inCorrects++;
            Debug.Log("Incorrect!");
        }

        // Remove the random question from the list
        questions.RemoveAt(indexCurrentQuestion);

        // move on to the next question or end the quiz
        if (questions.Count > 0)
        {
            DisplayQuestion();
        }
        else
        {
            Debug.Log("Quiz complete!");
            questionText.text = string.Format("Corrects: {0}\nIncorrects: {1}", corrects, inCorrects);
        }
    }

    private List<Question> LoadQuestions()
    {
        return QuestionLoader.GetQuestions(SceneCategory.value);
    }
}