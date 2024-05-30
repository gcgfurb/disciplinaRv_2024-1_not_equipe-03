using UnityEngine;

public class DummyPadBehaviour : MonoBehaviour
{
    [SerializeField] bool host;

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

        var spawner = FindObjectOfType<BasicSpawner>();

        if (host)
        {
            spawner.HostGame();
        }
        else
        {
            spawner.JoinGame();
        }
    }
}