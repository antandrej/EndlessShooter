using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemy;

    //public GameObject bullet;
    //public Transform shootPoint;

    public float shootSpeed = 10f;
    public float timeToShoot = 1.3f;
    float originalTime;

    void Start()
    {
        originalTime = timeToShoot;
    }

    void Update()
    {
        if (detected)
        {
            enemy.LookAt(target.transform.position);
            //enemy.LookAt(target.transform.position + new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)));
        }
    }

    private void FixedUpdate()
    {
        if (detected)
        {
            timeToShoot -= Time.deltaTime;

            if (timeToShoot < 0 && target.GetComponent<PlayerController>().isAlive)
            {
                ShootPlayer();
                timeToShoot = originalTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = true;
            target = other.gameObject;
        }
    }

    private void ShootPlayer()
    {
        /*
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        Destroy(currentBullet, 1.25f);
        rb.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
        */
        target.GetComponent<PlayerController>().currentHealth -= Random.Range(15, 25);
        Debug.Log("shoot" + gameObject);
    }
}
