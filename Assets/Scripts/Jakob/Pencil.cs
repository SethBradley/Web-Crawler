using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pencil : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DestroyPencil());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);


        }
    }

    IEnumerator DestroyPencil()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
