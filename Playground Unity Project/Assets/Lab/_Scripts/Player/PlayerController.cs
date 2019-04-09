using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Motor))]
public class PlayerController : MonoBehaviour
{
    private Motor motor;
    public CameraBase camBase;
    public CinemachineVirtualCamera vcam;


    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float horizontalLookSensitivity = 4f;
    [SerializeField] private float verticalLookSensitivity = 1f;


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

        bool _jump = Input.GetButtonDown("Jump");

        //Calculate rotation as a 3D vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X") * horizontalLookSensitivity;
        Vector3 _rotation = new Vector3(0f, _yRot, 0f);

        //Calculate camera movment.y as a float
        float _xRot = Input.GetAxisRaw("Mouse Y") * verticalLookSensitivity;
        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * verticalLookSensitivity;

        //float _yMouse = Input.GetAxisRaw("Mouse Y") * verticalLookSensitivity;


        motor.Move(_velocity);
        motor.Jump(_jump, jumpForce);
        motor.Rotate(_rotation);
        //motor.RotateCamera(_xRot, _yRot);
        camBase.RotateCamera(_cameraRotation);
    }
}
