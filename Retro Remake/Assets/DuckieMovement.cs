using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckieMovement: MonoBehaviour
{
    private float HorizontalInput;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        SetupDirectionByScale();
    }

    private void SetupDirectionByScale()
    {
        if (HorizontalInput < 0 && facingRight || HorizontalInput < 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector2 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }
}
