using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerPosition;
    public Transform crosshair;

    private Vector3 offset;


    void Start()
    {
        offset = new Vector3(0, 5.5f, -13);
    }

    
    void Update()
    {
        this.transform.position = playerPosition.position + offset;
    }

    private void LateUpdate()
    {
        //transform.LookAt(crosshair);
    }
}
