using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckieFlip : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
   private void FixedUpdate()
    {
        float y = 0;
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), y);
        sr.flipX = rb.velocity.x < 0f;
    }
}
