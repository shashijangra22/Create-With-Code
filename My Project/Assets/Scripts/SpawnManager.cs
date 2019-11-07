using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject powerUp;

    private float xSpawnRange = 16.0f;
    private float zPowerUpRange = 5.0f;
    private float ySpawn = 0.75f;
    private float zEnemySpawn = 12.0f;

    private float startDelay = 1.0f;
    private float enemySpawnTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerUp", startDelay, enemySpawnTime+5);
    }

    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-xSpawnRange,xSpawnRange);
        int randomIndex = Random.Range(0,enemies.Length);
        Vector3 spawnPos = new Vector3(randomX,ySpawn,zEnemySpawn);

        Instantiate(enemies[randomIndex],spawnPos,enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerUp()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPowerUpRange, zPowerUpRange);


        Vector3 spawnPos = new Vector3(randomX,ySpawn,randomZ);
        Instantiate(powerUp, spawnPos, powerUp.gameObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
