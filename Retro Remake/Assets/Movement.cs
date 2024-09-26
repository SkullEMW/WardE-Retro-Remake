
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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

    private void Move(Vector3 destination)
    {
        Collider2D barrier = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        Collider2D platform = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Platform"));
        Collider2D obstacle = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacle"));
      
        if (barrier != null)
        {
            return; 
        }

        if (platform != null)
        {
            transform.SetParent(platform.transform);
        }
        else
        {
            transform.SetParent(null); 
        }

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
