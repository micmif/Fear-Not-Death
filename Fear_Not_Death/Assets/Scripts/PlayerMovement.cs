using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool facingRight = true;
    [SerializeField] private float moveSpeed = 3.0f;
    private float moveH, moveV, moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() 
    {
        // Getting Direction Presses
        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveV = Input.GetAxisRaw("Vertical") * moveSpeed;

        // Setting condition for animation to play 
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
        Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false); 
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV);
        moveInput = Input.GetAxis("Horizontal");

    // Checking if player if facing right, if they are not, player sprite is flipped using the Flip() function.
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if(facingRight == true && moveInput < 0) {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
