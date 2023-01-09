using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingGlassWeapon : MonoBehaviour
{
    public GameObject magnifyingGlass;


    private void Awake()
    {
        StartCoroutine(SpawnMG());
    }
   
    

    IEnumerator SpawnMG()
    {
            
        yield return new WaitForSeconds(6);
        Instantiate(magnifyingGlass, gameObject.transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
        
        StartCoroutine(SpawnMG());
        yield break;
        
    }

    
}
