using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnSinglePlayer : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float radius = 10;
    public int numberZombie = 10;
    public int timeBetweenSpawn = 10; // 10 sec spawn numberZombie zombies

    private float lastSpawnTime = -100000;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine("SpawnZombie");
    }
    IEnumerator SpawnZombie()
    {
        for (; ; )
        {
            // Spawn numberZombie times
            for (int i = 0; i < numberZombie; ++i)
            {
                int xPos = Random.Range(-20, 20);
                int maxZ = (int)Mathf.Sqrt(radius * radius - xPos * xPos);
                int zPos = Random.Range(-maxZ, maxZ);

                Vector3 spawnLocation = transform.position + new Vector3(xPos, 0, zPos);
                Instantiate(zombiePrefab, spawnLocation, Quaternion.identity);
            }
            
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
