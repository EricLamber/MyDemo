using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLogic : MonoBehaviour
{
    [SerializeField] protected int Health;
    [SerializeField] private float DeathTimer;
    [SerializeField] protected float Speed;

    protected Animator animator;
    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected void TakeDamage()
    {
        if (Health <= 0)
        {
            animator.Play("Death");
            Invoke(nameof(Death), DeathTimer);
        }
        else
        {
            animator.Play("Hit");
            Health--;;
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
