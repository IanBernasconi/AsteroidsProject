using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;

    private float lifeTime;


    // OnEnable es llamado cada vez que el objeto es activado
    void OnEnable()
    {
        lifeTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;

        // Mueve la bala en la dirección targetVector
        transform.Translate(speed * Time.deltaTime * targetVector);

        // Desactiva la bala cuando su tiempo de vida se acaba
        if (lifeTime >= maxLifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        // Desactivar cuando sale de la pantalla
        gameObject.SetActive(false);
    }


    private void IncreaseScore()
    {
        Player.SCORE++;
        Debug.Log("Score: " + Player.SCORE);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score: " + Player.SCORE;
    }
}
