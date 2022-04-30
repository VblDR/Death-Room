using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float offsetY;


    private bool movement;


    private void LateUpdate()
    {
        if (Mathf.Abs(target.position.y - transform.position.y) > offsetY)    
            movement = true;

        if(movement)
            MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector3 targetPos = target.position;
        targetPos.x = transform.position.x;
        targetPos.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        if (Mathf.Abs(target.position.y - transform.position.y) < 0.1f)
            movement = false;
    }
}
