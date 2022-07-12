using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberGoblin : Enemy
{
    [SerializeField]
    private float yForceThrow = 1;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform projectileSpawnPoint;
    [SerializeField]
    private float coolDown;
    private float currentTime;


    protected override void FixedUpdate()
    {
        if (currentTime > 0)
            currentTime -= Time.fixedDeltaTime;
        
        if(live) 
            SearchPlayer();
    }


    public void SearchPlayer()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, distance, 1 << LayerMask.GetMask("Player"));
        if(player != null && currentTime <= 0)
        {
            if (player.transform.position.x < transform.position.x && isRight)
                Rotate();
            else if (player.transform.position.x > transform.position.x && !isRight)
                Rotate();

            Attack(player.transform);
            currentTime = coolDown;
        }
    }

    protected override void Attack(Transform target)
    {
        float xForceThrow = target.position.x - transform.position.x;
        GameObject _projectile = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);

        projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(xForceThrow, yForceThrow), ForceMode2D.Impulse);

    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
