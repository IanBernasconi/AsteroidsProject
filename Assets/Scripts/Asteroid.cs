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
            // Desactivamos el asteroide en lugar de destruirlo para reutilizarlo en el pool
            gameObject.SetActive(false);
            // Desactivamos el objeto (bullet) en lugar de destruirlo para reutilizarlo en el pool
            other.gameObject.SetActive(false);
            if (!isMiniAsteroid)
            {
                SpawnMiniAsteroids(other.transform.position);
            }
            else
            {
                IncreaseScore();
            }
        }
    }

    private void SpawnMiniAsteroids(Vector3 position)
    {
        Vector3 bisectriz = -position.normalized;

        Quaternion rotation1 = Quaternion.AngleAxis(separationAngle, Vector3.forward);
        Quaternion rotation2 = Quaternion.AngleAxis(-separationAngle, Vector3.forward);

        Vector3 direction1 = rotation1 * bisectriz;
        Vector3 direction2 = rotation2 * bisectriz;

        // GameObject miniAsteroid1 = Instantiate(miniAsteroidPrefab, position, Quaternion.identity);
        GameObject miniAsteroid1 = ObjectPool.SharedInstance.GetPooledObject("MiniAsteroid");
        if (miniAsteroid1 != null)
        {
            miniAsteroid1.transform.position = position;
            miniAsteroid1.SetActive(true);
        }
        // GameObject miniAsteroid2 = Instantiate(miniAsteroidPrefab, position + new Vector3(distanceBetweenSpawns, 0, 0), Quaternion.identity);
        GameObject miniAsteroid2 = ObjectPool.SharedInstance.GetPooledObject("MiniAsteroid");
        if (miniAsteroid2 != null)
        {
            miniAsteroid2.transform.position = position + new Vector3(distanceBetweenSpawns, 0, 0);
            miniAsteroid2.SetActive(true);
        }

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

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }


}
