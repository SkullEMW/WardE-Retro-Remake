
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float RLmovement = .75f;
    public float UDmovement = .82f;
    Vector2 vecRL;
    Vector2 vecUD;
    private float HorizontalInput;
    private bool facingRight = true;

    private void Start()
    {
        vecRL = new Vector2(RLmovement, 0);
        vecUD = new Vector2(0, UDmovement);
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
