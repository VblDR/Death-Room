using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Transform groundPos;

    //movement
    private float currentSpeed;
    private Rigidbody2D rb;
    private bool isGrounded = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGround();
        GetInput();
    }


    private void GetInput()
    {
        if (Input.GetKey(KeyCode.Space))
            Jump();

        if (Input.GetAxis("Horizontal") > 0)
            Move(1);
        else if(Input.GetAxis("Horizontal") < 0)
            Move(-1);
    }

    private void Jump()
    {
        if (isGrounded)
            rb.AddForce(new Vector2(0, jumpForce));

    }

    private void Move(int direction)
    {
        rb.velocity = new Vector2(direction * maxSpeed, rb.velocity.y);
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, 0.05f, 1 << LayerMask.NameToLayer("Room") | 1 << LayerMask.NameToLayer("Platform"));
    }
}
