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


    bool gameOver = false;
    

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            playerAudioSource.PlayOneShot(jumpSound);
            playerAnim.SetTrigger("Jump");
        }
        else if (isOnGround == true)
            playerAnim.SetTrigger("Run");

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
}
