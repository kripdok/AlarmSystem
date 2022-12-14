using UnityEngine;

public class MoveController : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeReference] private float _speed = 10f;
    [SerializeReference] private float _jumpHeight = 3f;
    private float _gravity = Physics.clothGravity.y;
    private Vector3 _velocity;
    private bool groundedPlayer;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = _controller.isGrounded;

        if (groundedPlayer && _velocity.y < 0f)
        {
            _velocity.y = -0.5f;
        }

        Runing();
        Jumping();
        GoDown();
    }

    private void Jumping()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
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
        _velocity.y += _gravity * 2f * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
