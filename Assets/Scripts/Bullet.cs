using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * targetVector);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
