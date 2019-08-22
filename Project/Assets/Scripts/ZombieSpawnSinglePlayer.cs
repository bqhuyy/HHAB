using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnSingleplayer : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int timeBetweenSpawn = 5; 

    void Start()
    {
        StartCoroutine("SpawnZombie");
    }

    IEnumerator SpawnZombie()
    {
        for (; ; )
        {
            Instantiate(zombiePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
