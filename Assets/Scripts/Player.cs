using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float jumpLimit;
    [SerializeField]
    private Transform groundPos;

    private Animator anim;
    private bool finished = false;

    //movement
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isRight = true;
    private bool jumping = false;



    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!finished)
        {
            CheckGround();
            GetInput();
            anim.SetFloat("velocityY", rb.velocity.y);
            anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        }
    }

    private void Update()
    {
        if (!finished)
        {
            if (Input.GetKeyDown(KeyCode.K))
                Attack();
        }

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
        anim.Play("Attack");

        RaycastHit2D[] ray = Physics2D.RaycastAll(transform.position + new Vector3(0, 0.3f, 0), isRight ? Vector2.right : Vector2.left, 1.5f);
        for(int i = 0; i < ray.Length; i++)
        {
            if (ray[i].transform.CompareTag("Activator"))
                ray[i].transform.GetComponent<Activator>().Activate();
            if (ray[i].transform.GetComponent<IDamageable>() != null)
                ray[i].transform.GetComponent<IDamageable>().TakeDamage();
        }
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        else
            jumping = false;

        Move(Input.GetAxis("Horizontal"));
    }

    private void Jump()
    {

        if (isGrounded)
            jumping = true;
            //    rb.AddForce(new Vector2(0, jumpForce));


        if((!jumping && isGrounded) || jumping)
        {
            if (rb.velocity.y < jumpLimit)
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpForce);
            else
                jumping = false;
        }
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

    public static void GameFinished()
    {
        instance.finished = true;
    }
}
