using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInteraction : MonoBehaviour
{
    public int answerIndex; // index of the answer associated with this button

    public void SelectAnswer()
    {
        // send a message to the quiz manager to select this answer
        FindObjectOfType<QuizManager>().SelectAnswer(answerIndex);
    }


    // public GameObject button;
    // public GameObject panel;
    // public UnityEvent onButtonPress;
    // public UnityEvent onButtonRelease;
    // GameObject presser;
    // bool isPressed;

    // void Start()
    // {
    //     isPressed = false;
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if(!isPressed)
    //     {
    //         button.transform.localPosition = new Vector3(0, 0.003f, 0);
    //         presser = other.gameObject;
    //         onButtonPress.Invoke();
    //         SelectPanel();
    //         isPressed = true;
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if(other == presser)
    //     {
    //         button.transform.localPosition = new Vector3(0, 0.015f, 0);
    //         onButtonRelease.Invoke();
    //         isPressed = false;
    //     }
    // }

    // public void SelectPanel()
    // {
    //     panel.SetActive(panel.activeSelf);
    // }

    // public void SpawnSphere()
    // {
    //     GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //     sphere.transform.localScale = new Vector3(0, 0.5f, 0.5f);
    //     sphere.transform.localPosition = new Vector3(0, 1, 2);
    //     sphere.AddComponent<Rigidbody>();
    // }
}
