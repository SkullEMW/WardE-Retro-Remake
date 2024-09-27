
using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float RLmovement = .75f;
    public float UDmovement = .82f;
    Vector2 vecRL;
    Vector2 vecUD;
    Vector2 destination;
    private float HorizontalInput;
    private bool facingRight = true;
    private bool barrier = true;

    private void Start()
    {
        vecRL = new Vector2(RLmovement, 0);
        vecUD = new Vector2(0, UDmovement);
        destination = new Vector3(rb.position.x, rb.position.y);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            rb.MovePosition(rb.position + vecUD);

        else if (Input.GetKeyDown(KeyCode.S))
            rb.MovePosition(rb.position - vecUD);

        else if (Input.GetKeyDown(KeyCode.A))
            rb.MovePosition(rb.position - vecRL);

        else if (Input.GetKeyDown(KeyCode.D))
            rb.MovePosition(rb.position + vecRL);

        HorizontalInput = Input.GetAxis("Horizontal");

        SetupDirectionByScale();

        Vector3 destination = rb.position;


    }

    private void SetupDirectionByScale()
    {
        if (HorizontalInput > 0 && facingRight || HorizontalInput < 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector2 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }
}

