using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWeapon : MonoBehaviour
{
    public GameObject scrollWheel;
    public float speed;


    private void Awake()
    {
     
    }

    public void Update()
    {
        float x = transform.parent.position.x - 2;
        float z = transform.parent.position.z;
        float y = Mathf.PingPong(Time.time * speed, 2) * 6 - 3;
        scrollWheel.transform.position = new Vector3(x, y, z);
    }
    
}
