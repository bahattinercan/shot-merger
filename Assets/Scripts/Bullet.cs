using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float m_Speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("DestroyItself", 5);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * m_Speed);
    }

    private void DestroyItself()
    {
        Destroy(gameObject);
    }
}