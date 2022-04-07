using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    private Animator anim;
    [SerializeField]
    private GameObject fire;
    private bool activated = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Activate()
    {
        if (!activated)
        {
            activated = true;
            anim.Play("Activation");
            StartCoroutine(HelperScripts.WaitFor(0.99f, delegate ()
            {
                fire.SetActive(true);
                GameController.ActivateNextStage();
            }));

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
