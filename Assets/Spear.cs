using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : DeathObject
{
    protected float xColliderScale, yColliderScale;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();

        xColliderScale = _collider.size.x;
        yColliderScale = _collider.size.y;

    }

    protected override void Start()
    {
        base.Start();

        currentTime = sleepTime;
    }

    protected override void Update()
    {
        base.Update();
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            SwitchState();
        }

    }

    protected override void SwitchCollider()
    {
        if (transform.rotation.eulerAngles.z == 0)
        {
            _collider.offset = new Vector2(0, _sprite.bounds.size.y - yColliderScale/2);
            _collider.size = new Vector2(xColliderScale, yColliderScale);
        }
        else if (transform.rotation.eulerAngles.z == 90f)
        {
            _collider.offset = new Vector2(0, _sprite.bounds.size.x - xColliderScale/2);
            _collider.size = new Vector2(yColliderScale, xColliderScale);
        }
        else if (transform.rotation.eulerAngles.z == 180f)
        {
            _collider.offset = new Vector2(0, _sprite.bounds.size.y - yColliderScale/2);
            _collider.size = new Vector2(xColliderScale, yColliderScale);

        }
        else if (transform.rotation.eulerAngles.z == 270f)
        {
            _collider.offset = new Vector2(0, _sprite.bounds.size.x - xColliderScale/2);
            _collider.size = new Vector2(yColliderScale, xColliderScale);
        }
    }
}
