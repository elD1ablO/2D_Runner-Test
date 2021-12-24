using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8;
    [SerializeField] bool isOnGround = true;

    private Rigidbody2D playerRb;
    bool gameOver = false;
    

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
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
            gameOver = true;
        }
            
    }
}
