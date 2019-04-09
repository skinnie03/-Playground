using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

[RequireComponent(typeof(Rigidbody))]
public class Motor : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;
    private Rigidbody rb;
    public Animator animator;


    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private LayerMask m_WhatIsGround;


    [SerializeField] private float gravity = -9.8f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    private float xRot = 0f;
    private float yRot = 0f;



    private bool jump = false;
    private float jumpForce = 0f;
    private bool m_Grounded;

    const float k_GroundedRadius = .3f;

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetGravityAtStart();
    }

    //Gets a movement vector
    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //Gets a rotational vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    /* First person
    //Gets a rotational vector
    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }
    */

    //Third person
    //Gets a rotational angle
    public void RotateCamera(float _xRot, float _yRot)
    {
        xRot = _xRot;
        yRot = _yRot;
    }

    public void Jump(bool _jump, float _jumpForce)
    {
        jump = _jump;
        jumpForce = _jumpForce;
    }

    private void FixedUpdate()
    {
        Debug.Log("Is Grounded = " + m_Grounded);
        PerformMovement();
        PerformRotation();
        PerformJump();

        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider[] colliders = Physics.OverlapSphere(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (vcam != null)
        {
            ///First person
            ///cam.transform.Rotate(-cameraRotation);
            
            float vcam_xRot = vcam.transform.eulerAngles.x;

            //Third person

            vcam.transform.RotateAround(transform.position, transform.right, -xRot);
            //vcam.transform.RotateAround(transform.position, transform.up, yRot);
        }

    }

    void PerformJump()
    {
        if (jump && m_Grounded)
        {
            m_Grounded = false;
            rb.AddForce(0f, jumpForce, 0f);
            animator.SetTrigger("Jump");
        }
    }

    void SetGravityAtStart()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
    }
}
