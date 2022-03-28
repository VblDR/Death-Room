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

    private Animator anim;

    //movement
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CheckGround();
        GetInput();
        anim.SetFloat("velocityY", rb.velocity.y);
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Attack();
    }

    public void Death()
    {
        anim.Play("Death");
        StartCoroutine(HelperScripts.WaitFor(0.4f, delegate ()
        {
            GameController.ReloadLevel();
        }));

    }

    public void Attack()
    {
        anim.SetBool("Attack", true);
        StartCoroutine(HelperScripts.WaitFor(0.1f, delegate ()
        {
            anim.SetBool("Attack", false);
        }));
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.Space))
            Jump();

        Move(Input.GetAxis("Horizontal"));
    }

    private void Jump()
    {
        if (isGrounded)
            rb.AddForce(new Vector2(0, jumpForce));

    }

    private void Move(float direction)
    {
        rb.velocity = new Vector2(direction * maxSpeed, rb.velocity.y);
        if(isRight && direction < 0)
        {
            isRight = false;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if(!isRight && direction > 0)
        {
            isRight = true;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, 0.05f, 1 << LayerMask.NameToLayer("Room") | 1 << LayerMask.NameToLayer("Platform"));
    }


}
