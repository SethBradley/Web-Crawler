using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 4f;
   private Rigidbody2D rb;
   private Transform target;
   private Vector2 moveDirection;
   public float attackDamage;
   public float health;
   public Animator _Animator;
   public float damageTaken;
   private bool isInDot;

   private void Awake()
   {
       rb = GetComponent<Rigidbody2D>();
       _Animator = GetComponent<Animator>();
   }

   private void Start()
   {
       target = GameObject.Find("Player").transform;
   }

   void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;

        }

        if (health < 0)
        {
            Destroy(gameObject);
        }

       
    }

   private void FixedUpdate()
   {
       if (target)
       {
           rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * MoveSpeed;
       }
       
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
       
        if (col.CompareTag("Weapon"))
        {
            damageTaken = col.GetComponent<Weapon>().attackDamage;
            _Animator.Play("HitAnimation");

            health -= damageTaken;


        }
    }

   private void OnTriggerStay2D(Collider2D col)
   {
       if (col.CompareTag("Dot"))
       {
           Debug.Log("Hit MG");
            isInDot = true;
           damageTaken = col.GetComponent<Weapon>().attackDamage;
           StartCoroutine(DamageOverTime());

       }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
       if (other.CompareTag("Dot"))
       {
            isInDot = false;
            StopCoroutine(DamageOverTime());
           
       }
   }

   private IEnumerator DamageOverTime()
   {
       if (isInDot)
       {
           
           yield return new WaitForSeconds(1f);
           health -= damageTaken;
           _Animator.Play("HitAnimation");
       }
       yield break;
   }
}
