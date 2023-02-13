using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerPosition;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 5.5f, -13);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerPosition.position + offset;
    }
}
