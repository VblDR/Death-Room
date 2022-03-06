using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    protected bool activated = true;

    SpriteRenderer _sprite;
    BoxCollider2D _collider;

    protected virtual void Awake()
    {
        runInEditMode = true;
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        _collider.offset = new Vector2(0, _sprite.bounds.size.y / 2);
        _collider.size = new Vector3(_sprite.bounds.size.x / transform.lossyScale.x,
                                     _sprite.bounds.size.y / transform.lossyScale.y,
                                     _sprite.bounds.size.z / transform.lossyScale.z);
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<Player>().Death();
    }
}
