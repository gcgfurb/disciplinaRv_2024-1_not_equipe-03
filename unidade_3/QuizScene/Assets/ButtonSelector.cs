using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelector : MonoBehaviour
{
    public int answerIndex; // index of the answer associated with this button

    public void SelectAnswer()
    {
        // send a message to the quiz manager to select this answer
        FindObjectOfType<QuizManager>().SelectAnswer(answerIndex);
    }
}