using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText; // reference to the question text object
    public List<TextMeshProUGUI> optionsTexts = new(); // list of references to the option text objects
    public Button nextButton; // reference to the next button object

    private List<Question> questions; // list of questions

    private Question currentQuestion;

    private int corrects;

    private int inCorrects;


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
        if (textMeshProObject == null) {
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
            if (textMeshProObject == null) {
                Debug.LogError(string.Format("GameObject '{0}' not found!", gameObjectName));
                continue;
            }
            optionsTexts.Add(textMeshProObject.GetComponent<TextMeshProUGUI>());
        }
    }

    void DisplayQuestion()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, questions.Count);
        // Load the random question
        currentQuestion = questions[randomIndex];
        // Remove the random question from the list
        questions.RemoveAt(randomIndex);
        
        // set the question text
        questionText.text = currentQuestion.question;

        // set the answer texts
        for (int i = 0; i < currentQuestion.options.Count; i++)
        {
            optionsTexts[i].text = currentQuestion.options[i];
        }

        // reset the button selectors
        foreach (ButtonSelector buttonSelector in FindObjectsOfType<ButtonSelector>())
        {
            buttonSelector.SelectAnswer();
        }
    }

    public void SelectAnswer(int answerIndex)
    {
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

        // move on to the next question or end the quiz
        if (questions.Count > 0)
        {
            DisplayQuestion();
        }
        else
        {
            Debug.Log("Quiz complete!");
            Debug.Log(string.Format("Corrects: {0}", corrects));
            Debug.Log(string.Format("Incorrects: {0}", inCorrects));
            // nextButton.gameObject.SetActive(false);
        }
    }

    private List<Question> LoadQuestions()
    {
        return QuestionLoader.GetQuestions(SceneCategory.value);
    }
}
