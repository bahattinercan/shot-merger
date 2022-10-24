using UnityEngine;

public class EndLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.FinishTheGame();
        }
    }
}