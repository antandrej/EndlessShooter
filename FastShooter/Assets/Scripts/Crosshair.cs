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

    Vector3 mousePos;
    Vector3 aim;

    void Start()
    {
        Cursor.visible = false;
        //originalTime = timeToShoot;
    }

    void Update()
    {
        this.transform.position = Input.mousePosition;

        //shootPoint.transform.LookAt(Input.mousePosition);
        //pointingTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.back * Camera.main.transform.position.z);
        //shootPoint.transform.LookAt(pointingTarget, Vector3.back);
        //Debug.DrawLine(shootPoint.transform.position, this.transform.position, Color.red);

        mousePos = Input.mousePosition;
        aim = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
            //if (timeToShoot < 0)
            //{
            //Debug.Log(hit.point);
            shootPoint.transform.LookAt(aim);
            GameObject currentBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
            currentBullet.transform.LookAt(aim);
            Debug.Log("metak");
            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            Destroy(currentBullet, 1.25f);
            //rb.AddForce(hit.point * shootSpeed, ForceMode.VelocityChange);
            rb.AddRelativeForce(-transform.forward * shootSpeed);
            //timeToShoot = originalTime;
            //}
            /*
            if (hit.transform.gameObject.tag == "Enemy")
            {
                //hit.transform.gameObject.GetComponent<EnemyController>().health -= Random.Range(30, 40);  --- U BULLET CONTROLLERU JE ~~~ VRATI OVDE
            }
            */
            //}
        }
    }
}
