using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float m_Speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("DestroyItself", 1f);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * m_Speed);
    }

    private void DestroyItself()
    {
        Vibration.Vibrate(50);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrel"))
        {
            other.GetComponent<Barrel>().DecreaseHealth();
            CancelInvoke();
            DestroyItself();
        }
    }    
}