using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput* speed, body.velocity.y);

        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }

        if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1 ,1);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }

    }
}
