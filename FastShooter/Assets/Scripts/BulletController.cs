using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    collision.gameObject.GetComponent<PlayerController>().currentHealth -= Random.Range(15, 25);
        //    Destroy(collision.gameObject);
        //}

        //if (collision.gameObject.tag == "Enemy")
        //{
        //    collision.gameObject.GetComponent<EnemyController>().health -= Random.Range(30, 40);
        //    Destroy(collision.gameObject);
        //}
    }
}
