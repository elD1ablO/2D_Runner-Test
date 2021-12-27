using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] obstaclePrefs;

    Vector2 spawnPosition = new Vector2(18, -3.5f);

    float startDelay = 2;
    float repeatRate = 2;
    void Start()
    {                
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        int enemyRandomizer = Random.Range(0, obstaclePrefs.Length);
        Instantiate(obstaclePrefs[enemyRandomizer], spawnPosition, obstaclePrefs[enemyRandomizer].transform.rotation);
    }
}
