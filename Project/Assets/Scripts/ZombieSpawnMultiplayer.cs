using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ZombieSpawnMultiplayer : NetworkBehaviour
{
    public GameObject zombiePrefab;
    public int timeBetweenSpawn = 5; // 5 sec spawn numberZombie zombies

    private void Start()
    {
        CmdStart();
    }

    [Command]
    void CmdStart()
    {
        StartCoroutine("SpawnZombies");
    }

    IEnumerator SpawnZombies()
    {
        for (; ; )
        {
            GameObject[] spawnLocations = GameObject.FindGameObjectsWithTag("ZombieSpawnMultiplayerLocation");
            for (int i = 0; i < spawnLocations.Length; ++i)
            {
                GameObject currentSpawnLocation = spawnLocations[i];
                GameObject go = Instantiate(zombiePrefab, currentSpawnLocation.transform.position, Quaternion.identity);
                NetworkServer.Spawn(go);
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
