
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        rb.MovePosition(rb.position + Vector2.up);

        if (Input.GetKeyDown(KeyCode.S))
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        rb.MovePosition(rb.position + Vector2.down);

        if (Input.GetKeyDown(KeyCode.A))
            transform.rotation = Quaternion.Euler(0f, 0f, -180f);
             Move(Vector3.left);

        if (Input.GetKeyDown(KeyCode.D))
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
             Move(Vector3.right);
    }
    private void Move(Vector3 direction)
    {
       Vector3 destination = transform.position + direction;
    }
}
