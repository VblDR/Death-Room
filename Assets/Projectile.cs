using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<IDamageable>() != null)
        {
            collision.transform.GetComponent<IDamageable>().TakeDamage();
        }

    }
}
