using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float distance;

    private float currentPos = 0;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Patrol(); 
    }

    private void Patrol()
    {
        if (currentPos == distance)
        {
            currentPos = 0;

        }
    }
}
