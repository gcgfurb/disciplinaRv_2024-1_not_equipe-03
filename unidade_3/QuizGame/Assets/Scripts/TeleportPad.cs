using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPadBehaviour : MonoBehaviour
{

    [SerializeField]
    int category;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        SceneCategory.value = category;

        Debug.Log("Collided with a Player");
        SceneManager.LoadScene("SampleScene");
    }
}
