using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 5;
    private Vector3 offset;
    private Transform PlayerTransform;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        offset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + PlayerTransform.position;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0f){
            Camera.main.fieldOfView += scroll * zoomSpeed;
            
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 30, 70);

        }
    }
}
