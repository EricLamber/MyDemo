using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : BaseLogic
{
    [SerializeField] private WallForEnemy Wall_1;
    [SerializeField] private WallForEnemy Wall_2;
    private Damage dmg;

    private int x = 1;
    private bool IsMoving;

    private void Start()
    {
        dmg = transform.Find("Hitbox").GetComponent<Damage>();
    }

    void FixedUpdate()
    {
        if (dmg.IsDamageTaken()==1)
            TakeDamage();
        else
        {
            Moving();
            Flip();
        }
    }

    private void Moving()
    {
        IsMoving = true;
        animator.SetBool("IsMoving", IsMoving);
        if(Wall_1.Wall() || Wall_2.Wall())
            x *= -1;
        rb.velocity = new Vector2(-x * Speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (rb.velocity.x < 0)
            spriteRenderer.flipX = true;
        else if (rb.velocity.x > 0)
            spriteRenderer.flipX = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            x *= -1;
    }

    
}
