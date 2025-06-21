using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    public Rigidbody2D playerRb;
    public float jumpForce = 10f;
    // public float slideDuration = 0.5f;
    private bool isGrounded = true;
    private bool isSliding = false;


    // private void Awake()
    // {
    //     throw new NotImplementedException();
    // }
    

    // Update is called once per frame
    void Update()
    {
        // Touch for jump
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpForce);
        }

        // Touch and hold for slide
        // if (Input.GetMouseButton(1) && isGrounded && !isSliding)
        // {
        //     StartCoroutine(SlideCoroutine());
        // }
    }
    
    // IEnumerator SlideCoroutine()
    // {
    //     isSliding = true;
    //     // Slide animation or scale down can be added here
    //     yield return new WaitForSeconds(slideDuration);
    //     isSliding = false;
    // }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            DinoMiniGame.Instance.HandleHit();
        }
    }
    
    
   
}
