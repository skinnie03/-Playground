using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Motor))]
public class PlayerController : MonoBehaviour
{
    private Motor motor;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private BoxCollider groundCheck;


    private void Start()
    {
        motor = GetComponent<Motor>();
    }

    private void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");
        //float _zMov = 1f;

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        bool _jump = Input.GetKeyDown(KeyCode.Z);

        motor.Move(_velocity);
        motor.Jump(_jump, jumpForce);
    }
}
