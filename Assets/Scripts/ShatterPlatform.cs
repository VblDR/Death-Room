using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterPlatform : MonoBehaviour
{
    [SerializeField]
    private float shatterTime;
    [SerializeField]
    private float restoreTime;

    private BoxCollider2D _collider;
    private Animator anim;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(HelperScripts.WaitFor(shatterTime, delegate ()
            {
                Shatter();
            }));
        }
    }

    private void Shatter()
    {
        anim.SetBool("Shatter", true);
        StartCoroutine(HelperScripts.WaitFor(0.45f, delegate ()
        {
            _collider.enabled = false;
        }));

        StartCoroutine(HelperScripts.WaitFor(restoreTime, delegate ()
        {
            Restore();
        }));
    }

    private void Restore()
    {
        anim.SetBool("Shatter", false);
        _collider.enabled = true;
    }
}
