using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    public GameObject miniAsteroidPrefab;
    public float separationAngle = 30f;
    public float speed = 10f;
    public int miniAsteroidsToSpawn = 2;

    public bool isMiniAsteroid = false;

    private static float distanceBetweenSpawns = 2f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            if (!isMiniAsteroid)
            {
                Debug.Log("Asteroid destroyed");
                SpawnMiniAsteroids(other.transform.position);
                Debug.Log("Mini asteroids spawned");
            }
            else
            {
                Debug.Log("Mini asteroid destroyed");
                IncreaseScore();
            }
        }
    }

    private void SpawnMiniAsteroids(Vector3 position)
    {
        // make the negative of the normal
        Vector3 bisectriz = -position.normalized;

        Quaternion rotation1 = Quaternion.AngleAxis(separationAngle, Vector3.forward);
        Quaternion rotation2 = Quaternion.AngleAxis(-separationAngle, Vector3.forward);

        Vector3 direction1 = rotation1 * bisectriz;
        Vector3 direction2 = rotation2 * bisectriz;

        GameObject miniAsteroid1 = Instantiate(miniAsteroidPrefab, position, Quaternion.identity);
        GameObject miniAsteroid2 = Instantiate(miniAsteroidPrefab, position + new Vector3(distanceBetweenSpawns, 0, 0), Quaternion.identity);
        miniAsteroid1.GetComponent<Rigidbody>().velocity = direction1 * speed;
        miniAsteroid2.GetComponent<Rigidbody>().velocity = direction2 * speed;

        Asteroid miniAsteroid1Script = miniAsteroid1.GetComponent<Asteroid>();
        Asteroid miniAsteroid2Script = miniAsteroid2.GetComponent<Asteroid>();
        miniAsteroid1Script.isMiniAsteroid = true;
        miniAsteroid2Script.isMiniAsteroid = true;

    }

    private void IncreaseScore()
    {
        Player.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score: " + Player.SCORE;
    }


}
