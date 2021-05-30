using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : SingletonMonobehaviour<Player>
{
    #region References

    private Rigidbody2D rb;
    public Transform groundCheck;
    private Animator anim;
    public MeshRenderer bgMesh;
    private Score score;
    private AnalyticsManager analyticsManager;

    #endregion

    #region Variables

    public LayerMask whatIsGround;
    public bool isGrounded;
    public float jumpForce;
    public float speed;
    private bool dead = false;
    private bool faceRight = true;

    private float timer = 0;

    private bool jumpBtnPressed = false;

    private int direction = 0;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bgMesh.material.mainTextureOffset = Vector2.zero;
        score = Score.Instance;
        analyticsManager = AnalyticsManager.Instance;
        analyticsManager.LevelStart();
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
            timer += Time.fixedDeltaTime;
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
            analyticsManager.LevelEnd(timer, score.scoreString);
           
            PlayerPrefs.SetString("LastScore", score.scoreString);
            PlayerPrefs.SetString("Status", "Completed");
            PlayerPrefs.SetFloat("Time", timer);
            SceneManager.LoadScene("Post");
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Meteor"))
        {
            SoundController.Instance.PlayDeath();
            PlayerPrefs.SetInt("Deaths", PlayerPrefs.GetInt("Deaths") + 1);
            dead = true;
            anim.SetBool("Dead", true);
            PlayerPrefs.SetInt("DeathByMeteor", PlayerPrefs.GetInt("DeathByMeteor") + 1);
            analyticsManager.DeathByMeteor(PlayerPrefs.GetInt("DeathByMeteor"), score.scoreString);
            PlayerPrefs.SetString("LastScore", score.scoreString);
            PlayerPrefs.SetString("Status", "Fail");
            PlayerPrefs.SetFloat("Time", timer);
            StartCoroutine(StartPostGame());
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("GameOver"))
        {
            SoundController.Instance.PlayDeath();
            PlayerPrefs.SetInt("Deaths", PlayerPrefs.GetInt("Deaths") + 1);
            dead = true;
            PlayerPrefs.SetInt("DeathByFall", PlayerPrefs.GetInt("DeathByFall") + 1);
            analyticsManager.DeathByFall(PlayerPrefs.GetInt("DeathByFall"), score.scoreString);
            PlayerPrefs.SetString("LastScore", score.scoreString);
            PlayerPrefs.SetString("Status", "Fail");
            PlayerPrefs.SetFloat("Time", timer);
            StartCoroutine(StartPostGame());
        }

        if (collision.gameObject.CompareTag("Bounce"))
        {
            SoundController.Instance.PlayJump();
        }

    }
    #endregion

    #region Private Methods

    private void Move()
    {

        Vector3 move = new Vector3(direction * speed, rb.velocity.y, 0f);
        rb.velocity = move;

        if (direction == -1)
        {
            anim.SetBool("Run", true);
            bgMesh.material.mainTextureOffset = new Vector2(bgMesh.material.mainTextureOffset.x - Time.fixedDeltaTime, bgMesh.material.mainTextureOffset.y);
            faceRight = false;
        }
        else if (direction == 1)
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
        if (jumpBtnPressed && isGrounded)
        {
            jumpBtnPressed = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool("Jump", true);
            SoundController.Instance.PlayJump();

        }

        if (isGrounded)
        {
            anim.SetBool("Jump", false);
            if(direction != 0 && !SoundController.Instance.run.isPlaying)
            {
                SoundController.Instance.PlayRun();
            }
        }
        else
        {
            anim.SetBool("Jump", true);
            SoundController.Instance.StopRun();
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

    public void JumpBtnDown()
    {
        jumpBtnPressed = true;
        SoundController.Instance.StopRun();
    }

    public void LeftBtnPressed()
    {
        direction = -1;
        SoundController.Instance.PlayRun();
    }

    public void RightBtnPressed()
    {
        direction = 1;
        SoundController.Instance.PlayRun();
    }

    public void BtnDirectionUp()
    {
        direction = 0;
        SoundController.Instance.StopRun();
    }


    #endregion

    #region Coroutines

    IEnumerator StartPostGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Post");
    }

    #endregion

}















