using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private Joystick joystick;
    public float m_Speed = 5f;

    private void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Store user input as a movement vector
        //Vector3 m_Input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 1);
        float horizontalInput = 0;
        if (joystick.Horizontal > 0 && joystick.Horizontal < .33f)
            horizontalInput = 0;
        else if (joystick.Horizontal < 0 && joystick.Horizontal > -.33f)
            horizontalInput = 0;
        else
            horizontalInput = joystick.Horizontal;
        Vector3 m_Input = new Vector3(horizontalInput, 0, 1);

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rb.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
    }
}