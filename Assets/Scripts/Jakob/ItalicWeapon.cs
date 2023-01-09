using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItalicWeapon : MonoBehaviour
{
    [SerializeField]public GameObject italic;
    public float speed;
    private float spawnRate;
    private Vector2 shootLocation;
    void Start()
    {
        shootLocation = Random.insideUnitCircle * 5;
        StartCoroutine(ShootItalic());
    }

    // Update is called once per frame
    private IEnumerator ShootItalic()
    {
        shootLocation = Random.insideUnitCircle * 5;
        spawnRate = UnityEngine.Random.Range(2,6);
        yield return new WaitForSeconds(1f);
        GameObject shootItalic = Instantiate(italic, gameObject.transform.position, transform.rotation);
        Rigidbody2D rb = shootItalic.GetComponent<Rigidbody2D>();
        rb.velocity = shootLocation * speed;
        StartCoroutine(ShootItalic());
      
      
    }
}
