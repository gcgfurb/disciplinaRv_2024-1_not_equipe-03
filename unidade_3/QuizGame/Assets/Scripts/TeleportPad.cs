using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPadBehaviour : MonoBehaviour
{
    [SerializeField] int category;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        SceneCategory.value = category;

        Debug.Log("Collided with a Player");
        SceneManager.LoadScene("SampleScene");
    }
}