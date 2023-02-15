using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;

    public float shootSpeed = 10f;
    //public float timeToShoot = 1.3f;
    //float originalTime;

    void Start()
    {
        Cursor.visible = false;
        //originalTime = timeToShoot;
    }

    void Update()
    {
        this.transform.position = Input.mousePosition;
        shootPoint.LookAt(this.transform);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //if (timeToShoot < 0)
                //{
                    //Debug.Log(hit.point);
                    GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                    Debug.Log("metak");
                    Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
                    Destroy(currentBullet, 1.25f);
                    rb.AddForce(hit.point * shootSpeed, ForceMode.VelocityChange);
                    //timeToShoot = originalTime;
                //}
                /*
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    //hit.transform.gameObject.GetComponent<EnemyController>().health -= Random.Range(30, 40);  --- U BULLET CONTROLLERU JE ~~~ VRATI OVDE
                }
                */
            }
        }
    }
}
