using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    public float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private BoxCollider2D boxCollider;
    private float wallJumpCoolDown;
    private float horizontalInput;
    private bool jumpBtnDown;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

  /*  private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }*/
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
      
        // Flip The Player When Moving Left-Right
        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }

        if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1 ,1);
        }

      
        // Set Animator Parameters
        anim.SetBool("grounded", isGrounded());
        anim.SetBool("run", horizontalInput != 0);
        // Wall Jump Logic
        if (wallJumpCoolDown > 0.2f)
        {
            

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 7;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }

        }
        else
        {
            wallJumpCoolDown += Time.deltaTime;
        }

      /*  if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, 0);
        }*/
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if(onWall() && !isGrounded())
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 8, 8);
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            wallJumpCoolDown = 0;
            
        }

        
        
    }
  
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        // return horizontalInput == 0 && isGrounded() && !onWall();
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 

        if (collision.gameObject.tag == "Princes")
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
