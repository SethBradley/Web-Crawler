using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskWeapon : MonoBehaviour
{
    public float speed;
    public Vector3 point;
    private Vector3 axis = new Vector3(0, 0, 1);
    void Update()
    {
        transform.RotateAround(transform.parent.position,axis,Time.deltaTime * speed);
  
    }
}
