using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float strafeSpeed = 10;

    public float maxHealth = 100;
    public float currentHealth = 100;

    public bool isAlive;

    void Start()
    {
        isAlive = true;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            this.gameObject.SetActive(false);
            isAlive = false;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        float x = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(x, 0, 0);
        transform.Translate(movement * strafeSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= Random.Range(15, 25);
            Destroy(collision.gameObject);
        }
    }
}
