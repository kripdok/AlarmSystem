using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class MoveController : MonoBehaviour
{
    [SerializeReference] private float _speed = 10f;
    [SerializeReference] private float _jumpHeight = 3f;
    private CharacterController _controller;
    private float _gravity = Physics.clothGravity.y;
    private float _fallAcceleration = 2.0f;
    private float _defoltVelocityY = -0.5f;
    private Vector3 _velocity;
    private bool _isGrounded;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrounded = _controller.isGrounded;

        if (_isGrounded && _velocity.y < 0f)
        {
            _velocity.y = _defoltVelocityY;
        }

        Runing();
        Jumping();
        GoDown();
    }

    private void Jumping()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -_fallAcceleration * _gravity);
        }
    }

    private void Runing()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * y;
        _controller.Move(move * _speed * Time.deltaTime);
    }

    private void GoDown()
    {
        _velocity.y += _gravity * _fallAcceleration * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
