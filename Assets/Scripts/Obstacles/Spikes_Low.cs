using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_Low : DeathObject   
{
    protected List<CapsuleCollider2D> _colliders = new List<CapsuleCollider2D>();

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();


    }

    protected override void Start()
    {
        runInEditMode = true;

        _sprite = GetComponent<SpriteRenderer>();
        foreach(CapsuleCollider2D _col in GetComponents<CapsuleCollider2D>())
            _colliders.Add(_col);
        currentTime = sleepTime;
    }

    protected override void Update()
    {
        foreach(CapsuleCollider2D _col in _colliders)
            SwitchCollider(_col);
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            SwitchState();
        }

    }

}
