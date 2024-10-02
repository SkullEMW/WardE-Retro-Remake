
using System.Collections;
using Unity.VisualScripting;
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
    private SpriteRenderer spriteRenderer;
    public Sprite deathsprite;
   
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
  
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

        destination = rb.position;
   

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
   

    private void Death()
    {
        spriteRenderer.sprite = deathsprite; 
        enabled = false;
        Debug.Log("dead");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        {
            Collider2D barrier = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("barrier"));
            Collider2D Obstacle = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacle"));
            Collider2D Platform = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Platform"));

            if (barrier != null)
            {
                return;
            }

            if (Platform != null)
            {
                transform.SetParent(Platform.transform);
            }

            else
            {
                transform.SetParent(null);
            }

            if (Obstacle != null && Platform == null)
            {
                transform.position = destination;
                Death();
            }
            
        }
        if (enabled && col.gameObject.layer != LayerMask.GetMask("obstacle") && transform.parent != null)
        {
            Death(); 
        }
    }
}

