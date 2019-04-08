using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBase : MonoBehaviour
{
    private Vector3 cameraRotation = Vector3.zero;

    //Gets a rotational vector
    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    private void FixedUpdate()
    {
        transform.Rotate(-cameraRotation);
    }
}
