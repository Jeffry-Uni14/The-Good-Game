using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 target;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        target = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
    }
}
