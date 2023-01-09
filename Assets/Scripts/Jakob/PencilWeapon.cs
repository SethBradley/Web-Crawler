using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PencilWeapon : MonoBehaviour
{
   [SerializeField]public GameObject pencil;
   public float speed;
   private float spawnRate;


   private void Start()
   {
      StartCoroutine(ShootPencil());
   }

   

   private IEnumerator ShootPencil()
   {
      spawnRate = UnityEngine.Random.Range(2,6);
      yield return new WaitForSeconds(1f);
      GameObject shootPencil = Instantiate(pencil, gameObject.transform.position, transform.rotation);
      Rigidbody2D rb = shootPencil.GetComponent<Rigidbody2D>();
      rb.velocity = Vector2.left * speed;
      StartCoroutine(ShootPencil());
     

   }
}
