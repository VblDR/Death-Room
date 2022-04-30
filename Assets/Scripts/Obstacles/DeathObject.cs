using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    [SerializeField]
    protected float activeTime;
    [SerializeField]
    protected float sleepTime;

    protected bool activated = false;
    protected Animator anim;
    protected float currentTime;

    protected SpriteRenderer _sprite;
    protected BoxCollider2D _collider;

    protected virtual void Awake()
    {
        runInEditMode = true;
        if (GetComponent<BoxCollider2D>() != null)
        {
            _sprite = GetComponent<SpriteRenderer>();
            _collider = GetComponent<BoxCollider2D>();
        }
    }

    protected virtual void Start()
    {

    }


    protected virtual void Update()
    {
        if (_collider != null)
        {
            SwitchCollider(_collider);
        }
        
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<Player>().Death();
    }

    protected virtual void SwitchState()
    {
        if (activated)
        {
            currentTime = sleepTime;
            anim.Play("Deactivation");
        }
        else
        {
            currentTime = activeTime;
            anim.Play("Activation");
        }
        activated = !activated;
    }

    protected virtual void SwitchCollider(BoxCollider2D _collider)
    {
        if (transform.rotation.eulerAngles.z == 0)
        {
            _collider.offset = new Vector2(0, _sprite.bounds.size.y / 2);
            _collider.size = new Vector3(_sprite.bounds.size.x / transform.lossyScale.x,
                                         _sprite.bounds.size.y / transform.lossyScale.y,
                                         _sprite.bounds.size.z / transform.lossyScale.z);
        }
        else if(transform.rotation.eulerAngles.z == 90f)
        {
            _collider.offset = new Vector2(0, _sprite.bounds.size.x / 2);
            _collider.size = new Vector3(_sprite.bounds.size.y / transform.lossyScale.y, 
                                         _sprite.bounds.size.x / transform.lossyScale.x,
                                         _sprite.bounds.size.z / transform.lossyScale.z);
        }
        else if(transform.rotation.eulerAngles.z == 180f)
        {
            _collider.offset = new Vector2(0, _sprite.bounds.size.y / 2);
            _collider.size = new Vector3(_sprite.bounds.size.x / transform.lossyScale.x,
                                         _sprite.bounds.size.y / transform.lossyScale.y,
                                         _sprite.bounds.size.z / transform.lossyScale.z);
        }
        else if (transform.rotation.eulerAngles.z == 270f)
        {
            _collider.offset = new Vector2(0, _sprite.bounds.size.x/ 2);
            _collider.size = new Vector3(_sprite.bounds.size.y / transform.lossyScale.y,
                                         _sprite.bounds.size.x / transform.lossyScale.x,
                                         _sprite.bounds.size.z / transform.lossyScale.z);
        }
    }

    protected virtual void SwitchCollider(CapsuleCollider2D _collider)
    {
        if (transform.rotation.eulerAngles.z == 0)
        {
            _collider.offset = new Vector2(_collider.offset.x, _sprite.bounds.size.y / 2);
        }
        else if (transform.rotation.eulerAngles.z == 90f)
        {
            _collider.offset = new Vector2(_collider.offset.y, _sprite.bounds.size.x / 2);
        }
        else if (transform.rotation.eulerAngles.z == 180f)
        {
            _collider.offset = new Vector2(_collider.offset.x, _sprite.bounds.size.y / 2);
        }
        else if (transform.rotation.eulerAngles.z == 270f)
        {
            _collider.offset = new Vector2(_collider.offset.y, _sprite.bounds.size.x / 2);
        }
    }
}
