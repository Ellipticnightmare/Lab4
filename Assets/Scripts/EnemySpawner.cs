using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public int enemyCount;
    public int nextNameNumber;

    // Start is called before the first frame update
    private void Awake()
    {
        enemyCount = 0;
        nextNameNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount < 4)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            
            GameObject enemyClone = Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
            enemyClone.name = "enemy" + nextNameNumber;
            enemyCount++;
            nextNameNumber++; 
        }
    }
}
