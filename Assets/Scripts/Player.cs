using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float deceleration;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Transform groundPos;



    //movement
    private float currentSpeed;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float velocityX = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGround();
        GetInput();
    }

    public void Death()
    {
        Debug.Log("Player Died!");
        GameController.ReloadLevel();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.Space))
            Jump();

        if (Input.GetAxis("Horizontal") > 0)
            Move(1);
        else if (Input.GetAxis("Horizontal") < 0)
            Move(-1);
        else
            SlowDown();
    }

    private void Jump()
    {
        if (isGrounded)
            rb.AddForce(new Vector2(0, jumpForce));

    }

    private void Move(int direction)
    {
        if (Mathf.Abs(velocityX) < maxSpeed) 
            velocityX += direction * acceleration;
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    private void SlowDown()
    {
        if (rb.velocity.x != 0)
        {

            velocityX = 0;
            rb.velocity += new Vector2(-deceleration * rb.velocity.x, 0);
            if (Mathf.Abs(rb.velocity.x) < 0.1f)
                rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, 0.05f, 1 << LayerMask.NameToLayer("Room") | 1 << LayerMask.NameToLayer("Platform"));
    }


}
