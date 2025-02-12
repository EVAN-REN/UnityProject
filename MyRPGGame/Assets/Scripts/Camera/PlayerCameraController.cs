using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    
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
    }
}
