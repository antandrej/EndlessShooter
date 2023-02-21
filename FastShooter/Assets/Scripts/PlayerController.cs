using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject crosshair;

    public float speed = 10;
    //public float strafeSpeed = 10;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public bool isAlive;


    void Start()
    {
        isAlive = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        healthBar.SetHealth(currentHealth);
        //transform.LookAt(new Vector3(crosshair.transform.position.x, transform.position.y, transform.position.z));
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
        /*
        Vector3 movement = new Vector3(x, 0, 0);
        transform.Translate(movement * strafeSpeed * Time.deltaTime);
        */
    }
}
