using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ public float moveSpeed = 5f;

    public Rigidbody2D rb;
    

    private Vector2 movement;

   
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
    }
}
