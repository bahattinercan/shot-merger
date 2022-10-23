using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float forceValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(0, 0, forceValue, ForceMode.Impulse);
        }
    }
}