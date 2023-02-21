using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
    public GameObject player;

    public float shootSpeed = 10f;
    //public float timeToShoot = 1.3f;
    //float originalTime;

    //Vector3 mousePos;
    //Vector3 aim;

    public int maxAmmo = 17;
    public int currentAmmo;

    void Start()
    {
        Cursor.visible = false;
        currentAmmo = maxAmmo;
        //originalTime = timeToShoot;
    }

    void Update()
    {
        this.transform.position = Input.mousePosition;

        if (player.GetComponent<PlayerController>().isAlive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //if (timeToShoot < 0)
                    //{
                    //timeToShoot = originalTime;
                    if (hit.transform.gameObject.tag == "Enemy" && Vector3.Distance(shootPoint.transform.position, hit.transform.position) <= 50)
                    {
                        hit.transform.gameObject.GetComponent<EnemyController>().health -= Random.Range(30, 40);
                        hit.transform.gameObject.GetComponent<EnemyController>().hit = true;
                    }
                    //}
                }
            }
        }
    }
}
