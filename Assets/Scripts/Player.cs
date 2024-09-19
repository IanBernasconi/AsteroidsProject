using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float thrustForce = 5f;
    public float rotationSpeed = 120f;

    public GameObject gun, bulletPrefab;

    private Rigidbody _rigid;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrust * thrustForce * thrustDirection);

        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

        if (Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.targetVector = thrustDirection;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
