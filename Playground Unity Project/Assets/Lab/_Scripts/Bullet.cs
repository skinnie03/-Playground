using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float bulletSpeed = 20f;
    Vector3 m_EulerAngleVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
        m_EulerAngleVelocity = new Vector3(20, 20, 20);
    }

    private void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

}
