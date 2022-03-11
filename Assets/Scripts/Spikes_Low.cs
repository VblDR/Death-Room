using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_Low : DeathObject   
{
    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();

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
        if(currentTime <= 0)
        {
            SwitchState();
        }

    }

}
