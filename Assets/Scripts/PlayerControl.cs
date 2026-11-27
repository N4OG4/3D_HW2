using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float speed = 500f;
    public GameManager gameManager;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    private Vector3 spawnPosition = new Vector3(9.88f, 0.5f, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementV = movementValue.Get<Vector2>();

        movementX = movementV.x;
        movementY = movementV.y;
    }

    void FixedUpdate()
    {
        //Debug.Log(rb.linearVelocity.magnitude);
        Vector3 movement = new Vector3(movementX, 0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hole"))
        {
            rb.position = spawnPosition;

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            gameManager.AddPenalty();
        }
    }
}