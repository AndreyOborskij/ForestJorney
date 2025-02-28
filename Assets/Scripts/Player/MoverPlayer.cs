using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Flipper _flipperPlayer;
    [SerializeField] private GroundChecker _groundCheck;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;

    private Vector2 _movement;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move(_inputReader.Direction);

        Jump(_inputReader.IsJump);
    }

    private void Move(float direction)
    {
        _movement = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);

        _rigidbody.velocity = _movement;

        _flipperPlayer.Flip(direction);
    }

    private void Jump(bool isJump)
    {
        if (isJump == true && _groundCheck.IsGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}