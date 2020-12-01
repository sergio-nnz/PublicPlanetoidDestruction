using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    [SerializeField] private int asteroidsPerSpawn = 1;
    [SerializeField] private int spawnsBeforeIncrement = 20;
    [SerializeField] private float timeBetweenSpawn = 1;
    [SerializeField] private bool isSpawnEnabled = true;

    [SerializeField] private Transform lowerLimit;
    [SerializeField] private Transform upperLimit;
    
    private WaitForSeconds spawnDelay;

    public bool IsSpawnEnabled
    {
        set => isSpawnEnabled = value;
    }

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // TODO: Add all of this logic to a separate class
    private void SpawnAsteroids(int numberOfAsteroids)
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        var lowerLimitPosition = lowerLimit.position;
        var upperLimitPosition = upperLimit.position;
        var x = Random.Range(lowerLimitPosition.x, upperLimitPosition.x);
        var y = Random.Range(lowerLimitPosition.y, upperLimitPosition.y);
        var z = this.transform.position.z;
        
        
        var asteroidPosition = new Vector3(x, y, z);
        Instantiate(asteroid, asteroidPosition, this.gameObject.transform.rotation);
    }


    private IEnumerator SpawnRoutine()
    {
        spawnDelay = new WaitForSeconds(timeBetweenSpawn);
        int spawnCount = 0;
        
        while (isSpawnEnabled)
        {
            if (spawnCount >= spawnsBeforeIncrement)
            {
                asteroidsPerSpawn += 1;
                spawnCount = 0;
            }

            yield return spawnDelay;
            SpawnAsteroids(asteroidsPerSpawn);
            spawnCount += 1;
        }
    }
}
