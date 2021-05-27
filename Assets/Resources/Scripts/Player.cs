﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : SingletonMonobehaviour<Player>
{
    #region References

    private Rigidbody2D rb;
    public Transform groundCheck;
    private Animator anim;
    public MeshRenderer bgMesh;
    private Score score;

    #endregion

    #region Variables

    public LayerMask whatIsGround;
    public bool isGrounded;
    public float jumpForce;
    public float speed;
    private bool dead = false;
    private bool faceRight = true;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bgMesh.material.mainTextureOffset = Vector2.zero;
        score = Score.Instance;
    }

    void Update()
    {
        if (!dead)
        {
            Jump();
            CheckSide();
        }
        bgMesh.transform.position = new Vector3(transform.position.x, bgMesh.transform.position.y, bgMesh.transform.position.z);

    }

    void FixedUpdate()
    {
        if (!dead)
        {
            isGrounded = Physics2D.OverlapPoint(groundCheck.position, whatIsGround);
            Move();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Egg"))
        {
            score.ScoreUp();
            Destroy(collision.gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Final"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Meteor"))
        {
            dead = true;
            anim.SetBool("Dead", true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("GameOver"))
        {
            dead = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        

    }


    #endregion

    #region Private Methods

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
        rb.velocity = move;

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Run", true);
            bgMesh.material.mainTextureOffset = new Vector2(bgMesh.material.mainTextureOffset.x - Time.fixedDeltaTime, bgMesh.material.mainTextureOffset.y);
            faceRight = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Run", true);
            bgMesh.material.mainTextureOffset = new Vector2(bgMesh.material.mainTextureOffset.x + Time.fixedDeltaTime, bgMesh.material.mainTextureOffset.y);
            faceRight = true;
        }
        else
        {
            anim.SetBool("Run", false);
        }


    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool("Jump", true);

        }

        if (isGrounded)
        {
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }
    }

    private void CheckSide()
    {
        if (faceRight)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
        else
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }
    }

    #endregion

    #region Public Methods
    #endregion
}















