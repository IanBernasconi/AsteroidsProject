using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float xlimit;
    public float maxMeteorLife = 4f;
    private float spawnNext = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-xlimit, xlimit);

            Vector2 spawnPosition = new Vector2(rand, 8f);

            // GameObject meteor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            // GameObject meteor = ObjectPool.SharedInstance.GetPooledObject("Asteroid");
            // if (meteor != null)
            // {
            //     meteor.transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
            //     meteor.SetActive(true);
            //     Debug.Log("Meteor spawning");

            // }

            // Destroy(meteor, maxMeteorLife);

            // if (lifeTime >= maxMeteorLife)
            // {
            //     meteor.SetActive(false);
            // }
        }
    }
}
