using UnityEngine;

public class Player : MonoBehaviour
{
    #region References

    private Rigidbody2D rb;
    public Transform groundCheck;
    private Animator anim;
    #endregion

    #region Variables

    public LayerMask whatIsGround;
    public bool isGrounded;
    public float jumpForce;
    public float speed;
    private bool dead = false;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            dead = true;
            anim.SetBool("Dead", true);
        }

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapPoint(groundCheck.position, whatIsGround);
        Move();
    }

    #endregion

    #region Private Methods

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
        rb.velocity = move;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }





    #endregion

    #region Public Methods
    #endregion
}















