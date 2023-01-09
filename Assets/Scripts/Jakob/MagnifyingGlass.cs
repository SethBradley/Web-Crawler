using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingGlass : MonoBehaviour
{
    private Transform target;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float desiredDuration = 1f;
    private float elapsedTime;
    public Animator _animator;


    private void Awake()
    {
        StartCoroutine(FindTarget());
        startPosition = transform.position;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (target)
        {
            StartCoroutine(GoToTarget());
        }
        
    }

    private IEnumerator FindTarget()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").transform;
        endPosition = target.transform.position;

        yield break;
        
    }
    private IEnumerator GoToTarget()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;
        
        transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        _animator.Play("MagnifyingGlassAnim");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    
}
