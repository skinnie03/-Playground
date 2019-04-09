using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float newGravity = -50f;

    void Start()
    {
        Physics.gravity = new Vector3 (0f, -50f, 0f);
    }
}
