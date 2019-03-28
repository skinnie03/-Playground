using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Motor : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private LayerMask m_WhatIsGround;
    public Animator animator;

    private Vector3 velocity = Vector3.zero;
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
    }

    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Jump(bool _jump, float _jumpForce)
    {
        jump = _jump;
        jumpForce = _jumpForce;
    }

    private void FixedUpdate()
    {
        Debug.Log(m_Grounded);
        PerformMovement();
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

    void PerformJump()
    {
        if (jump && m_Grounded)
        {
            m_Grounded = false;
            rb.AddForce(0f, jumpForce, 0f);
        }
    }
}
