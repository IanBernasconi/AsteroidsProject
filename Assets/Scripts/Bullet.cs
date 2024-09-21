using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 1f;
    public Vector3 targetVector;

    // Update is called once per frame
    void Update()
    {
        // Mueve la bala en la dirección targetVector
        transform.Translate(speed * Time.deltaTime * targetVector);

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
