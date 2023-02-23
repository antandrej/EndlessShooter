using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
    public GameObject player;

    public Text ammo;

    private float timeStamp;
    public float cooldown;
    //private float sCooldown;

    //Vector3 mousePos;
    //Vector3 aim;

    public float reloadTime;
    public int maxAmmo = 17;
    public int currentAmmo;
    private bool isReloading = false;

    void Start()
    {
        Cursor.visible = false;
        currentAmmo = maxAmmo;

        //sCooldown = cooldown;
    }

    void Update()
    {
        transform.position = Input.mousePosition;
        ammo.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();


        if (player.GetComponent<PlayerController>().isAlive)
        {
            if (isReloading)
            {
                return;
            }
            if (currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && timeStamp <= Time.time && currentAmmo >= 1)
                {
                    timeStamp = Time.time + cooldown;

                    currentAmmo --;

                    if (hit.transform.gameObject.tag == "Enemy" && Vector3.Distance(shootPoint.transform.position, hit.transform.position) <= 100)
                    {
                        hit.transform.gameObject.GetComponent<EnemyController>().health -= Random.Range(30, 40);
                        hit.transform.gameObject.GetComponent<EnemyController>().hit = true;
                    }

                }
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}