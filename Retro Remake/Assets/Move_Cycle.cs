using System.Net.Security;

using UnityEngine;

public class Move_Cycle : MonoBehaviour
{
    public Vector3 direction = Vector3.right;
    public float speed = 1f;
    public int size = 1;
   

    private Vector3 leftEdge;
    private Vector3 rightEdge;
    public void Start()
    {
        leftEdge = Camera.main.ViewportToWorldPoint(Vector3.left);
        rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
    }
    private void Update()
    {
        if (direction.x > 0 && (transform.position.x - size) > rightEdge.x)
        {
            Vector3 position = transform.position;
            position.x = leftEdge.x - size;
            transform.position = position;
        }
        else if (direction.x < 0 && (transform.position.x + size) < leftEdge.x)
        {
            Vector3 position = transform.position;
            position.x = rightEdge.x + size;
            transform.position = position;
        }
        else
        {
            transform.Translate(speed * Time.deltaTime * direction);
        }
    }
}