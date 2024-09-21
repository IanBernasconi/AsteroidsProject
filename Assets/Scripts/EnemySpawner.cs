using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float xlimit;
    private float spawnNext = 0;

    public float speed = 3f;

    // Update is called once per frame
    void Update()
    {


        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-xlimit, xlimit);

            Vector2 spawnPosition = new Vector2(rand, 8f);

            GameObject meteor = ObjectPool.SharedInstance.GetPooledObject("Asteroid");
            if (meteor != null)
            {
                Rigidbody rb = meteor.GetComponent<Rigidbody>();
                rb.velocity = new Vector3(0, -speed, 0);
                meteor.transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
                meteor.SetActive(true);

            }
        }
    }
}
