using System.Net.Security;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Move_Cycle : MonoBehaviour
{
    public Vector2 direction = Vector2.right;
    public float speed = 1f;
    public int size = 1;

    private Vector2 leftEdge;
    private Vector2 rightEdge;
    public void Start()
    {
        leftEdge = Camera.main.ViewportToWorldPoint(Vector2.zero);
        rightEdge = Camera.main.ViewportToWorldPoint(Vector2.right);
    }
    private void Update()
    {
        if (direction.x > 0 && (transform.position.x - size) > rightEdge.x)
        {
            Vector2 position = transform.position;
            position.x = leftEdge.x - size;
            transform.position = position;
        }
        if (direction.x < 0 && (transform.position.x +size) > leftEdge.x)
        {
            Vector2 position = transform.position;
            position.x = rightEdge.x + size;
            transform.position = position;
        }
       transform.Translate(direction * speed * Time.deltaTime);
        
    }

  }

