using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] obstaclePrefs;
    float startDelay = 2;
    float repeatRate = 2;

    void Start()
    {                
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        int enemyRandomizer = Random.Range(0, obstaclePrefs.Length);
        Vector2 spawnPosition = new Vector2(18, Random.Range(-3.5f, 3f));
        Instantiate(obstaclePrefs[enemyRandomizer], spawnPosition, obstaclePrefs[enemyRandomizer].transform.rotation);
    }
}
