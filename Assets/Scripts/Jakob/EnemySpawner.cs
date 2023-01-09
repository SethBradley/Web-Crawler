using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<_spawnpoint> spawnpoints = new List<_spawnpoint>();
    private GameObject[] spawnpoint;
    public List<GameObject> Enemies = new List<GameObject>();
    
    private void Awake()
    {
        spawnpoint = GameObject.FindGameObjectsWithTag("Spawn");
        spawnpoints.Clear();
        for (int i = 0; i < spawnpoint.Length; i++)
        {
            var _obj = new _spawnpoint()
            {
                addedSpawnpoint =  spawnpoint[i]
            };
            spawnpoints.Add(_obj);

        }
        
    }
    [System.Serializable]
    public class _spawnpoint
    {
        public GameObject addedSpawnpoint;
            
            
    }

    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
            
        yield return new WaitForSeconds(2);
        int enemyRan = UnityEngine.Random.Range(0, Enemies.Count);
        int ranroll = UnityEngine.Random.Range(0, spawnpoints.Count);
        Instantiate(Enemies[enemyRan], spawnpoint[ranroll].transform.position, Quaternion.identity);
        StartCoroutine(spawnEnemy());
        
    }
}
