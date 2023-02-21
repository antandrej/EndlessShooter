using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 100;

    public Material mat;
    public bool hit;

    void Start()
    {
        mat.color = Color.red;
        hit = false;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (hit)
        {
            StartCoroutine(EnemyHit());
        }
    }

    IEnumerator EnemyHit()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        hit = false;
    }
}
