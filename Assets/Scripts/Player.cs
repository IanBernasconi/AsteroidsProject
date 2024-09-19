using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public static int SCORE = 0;
    public static float xBorderLimit, yBorderLimit;
    public float thrustForce = 5f;
    public float rotationSpeed = 120f;

    public GameObject gun, bulletPrefab;

    private Rigidbody _rigid;

    public float fireRate = 0.4f;
    private float nextFireTime = 0f;

    Vector2 thrustDirection;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        xBorderLimit = Camera.main.orthographicSize + 1;
        yBorderLimit = (Camera.main.orthographicSize + 1) * Screen.width / Screen.height;
    }

    private void FixedUpdate()
    {
        float rotation = Input.GetAxis("Rotate") * rotationSpeed * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * thrustForce * Time.deltaTime;
        thrustDirection = transform.right;

        transform.Rotate(Vector3.forward, -rotation);

        _rigid.AddForce(thrustDirection * thrust);
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = transform.position;
        if (newPos.x > xBorderLimit)
        {
            newPos.x = -xBorderLimit + 1;
        }
        else if (newPos.x < -xBorderLimit)
        {
            newPos.x = xBorderLimit - 1;
        }
        else if (newPos.y > yBorderLimit)
        {
            newPos.y = -yBorderLimit + 1;
        }
        else if (newPos.y < -yBorderLimit)
        {
            newPos.y = yBorderLimit - 1;
        }
        transform.position = newPos;


        // Vector3 thrustDirection = transform.right;

        // _rigid.AddForce(thrust * thrustForce * thrustDirection);

        // transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.targetVector = thrustDirection;

            nextFireTime = Time.time + fireRate;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
