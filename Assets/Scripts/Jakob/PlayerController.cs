using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public float health;
    public float maxHealth;
    public Animator _Animator;

    private Vector2 movement;

    private void Awake()
    {
        health = maxHealth;
        _Animator = GetComponent<Animator>();
    }


    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        float hitAmount;
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            hitAmount = col.gameObject.GetComponent<Enemy>().attackDamage;


            health -= hitAmount;
            _Animator.Play("HitAnimation");
            Debug.Log(health);


        }
        
    }
}

