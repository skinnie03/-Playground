using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    public Vector3 dir = Vector3.up;
    public Vector3 velocity = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocity = dir * speed;
    }

    private void Update()
    {
        PerformMovement();
    }

    public void PerformMovement()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
    public void Flip()
    {
        dir = -dir;
        velocity = dir * speed;
    }
}
