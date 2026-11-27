using UnityEngine;

public class Balls : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hole") && gameObject.activeSelf)
        {
            gameObject.SetActive(false);

            gameManager.RefreshScore();
        }
    }
}