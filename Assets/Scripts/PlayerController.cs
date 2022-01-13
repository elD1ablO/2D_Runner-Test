using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8;
    [SerializeField] bool isOnGround = true;

    public ParticleSystem deathParticles;
    public AudioClip jumpSound;

    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private AudioSource playerAudioSource;
    private SpriteRenderer playerSprite;
    private int antiGravity = -1;

    Vector2 upsideRotation = new Vector2(180,0);

    bool gameOver = false;
    bool rotatePlayer = false;
    

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && rotatePlayer == false)
        {
            Jump(jumpForce);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isOnGround && rotatePlayer == true)
        {
            Jump(-jumpForce);
        }

        else if (isOnGround == true)
            playerAnim.SetTrigger("Run");

        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround)
        {
            playerRb.gravityScale *= antiGravity;
            Rotate();            
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gameOver != true)
        {            
            GameManager.instance.PauseMenuUI();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            //deathParticles.Play();
            GameManager.instance.GameOverMenuUI();
            gameOver = true;
            
        }            
    }

    void Rotate()
    {
        if (rotatePlayer == false)
        {
            transform.eulerAngles = new Vector3(180,0,0);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }

        rotatePlayer = !rotatePlayer;
    }

    void Jump(float _jumpForce)
    {
        playerRb.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
        isOnGround = false;
        playerAudioSource.PlayOneShot(jumpSound);
        playerAnim.SetTrigger("Jump");
    }
}
