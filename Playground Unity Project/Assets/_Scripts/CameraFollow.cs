using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField] Vector3 camOffset;

    private void Update()
    {
        transform.position = playerTransform.position + camOffset;
    }
}
