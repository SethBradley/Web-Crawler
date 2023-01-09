using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Italic : MonoBehaviour
{
    private float hitCount;
    private Rigidbody2D rb;
    private Vector3 lastVelocity;
    public Vector3 location;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hitCount = 0;
        
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("Hit");
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, col.ClosestPoint(location));
            rb.velocity = direction;


        }
    }
    
}
