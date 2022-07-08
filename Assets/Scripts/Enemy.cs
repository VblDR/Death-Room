using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float distance;

    protected bool isRight = true;
    protected Vector2 dirPos;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected bool live = true;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dirPos = transform.localPosition;
        dirPos.x += distance;
    }

    private void FixedUpdate()
    {
        if(live)
            Patrol(); 
    }

    private void Patrol()
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, dirPos, speed * Time.fixedDeltaTime);
        if (Vector2.Distance(dirPos, transform.localPosition) <= 0.1f)
        {
            if (isRight)
                dirPos.x -= distance;
            else
                dirPos.x += distance;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            isRight = !isRight;
        }
    }

    public void Death()
    {
        live = false;
        animator.Play("Death");
        StartCoroutine(HelperScripts.WaitFor(1, delegate ()
        {
            Destroy(gameObject);
        }));
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

        if (live && collision.transform.CompareTag("Player"))
            collision.transform.GetComponent<Player>().Death();
    }

}
