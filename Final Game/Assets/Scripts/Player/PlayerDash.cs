
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    private Rigidbody2D rb;
    private float dashTime;
    public float dashSpeed;
    public float startDashTime;
    private int direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.X))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.Z))
            {
                direction = 2;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {

                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }

}
