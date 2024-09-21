using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 1f;
    public Vector3 targetVector;

    private float lifetime = 0f;

    // Update is called once per frame
    void Update()
    {
        // Incrementar el tiempo de vida de la bala
        lifetime += Time.deltaTime;
        // Mueve la bala en la dirección targetVector
        transform.Translate(speed * Time.deltaTime * targetVector);

        // if (lifetime >= maxLifeTime)
        // {
        //     // Desactivar la bala cuando se cumple el tiempo de vida
        //     gameObject.SetActive(false);
        // }
    }

    private void OnBecameInvisible()
    {
        // Desactivar cuando sale de la pantalla
        ObjectPool.SharedInstance.ReturnObjectToPool("Bullet", gameObject);
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
