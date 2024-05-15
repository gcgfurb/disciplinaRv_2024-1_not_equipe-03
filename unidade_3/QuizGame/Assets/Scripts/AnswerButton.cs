using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerButton : MonoBehaviour
{
    public int answerIndex;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnButtonPress()
    {
        //SceneManager.LoadScene("LobbyScene");
        FindObjectOfType<QuizManager>().SelectAnswer(answerIndex);
    }
}
