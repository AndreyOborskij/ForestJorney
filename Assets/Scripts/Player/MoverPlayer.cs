using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = "Jump";

    [SerializeField] private InputReader _inputReader;
    [SerializeField] private FlipperPlayer _flipperPlayer;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _jumpForce; 
    [SerializeField] private float _moveSpeed;

    private Vector2 _movement;
    private Rigidbody2D _rigidbody; 
    private float _direction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        _flipperPlayer.Flip(_direction);

        if (Input.GetButtonDown(Jump) && _groundCheck.IsGrounded)
        {
            JumpAction();
        }

        UpdateAnimator();
    }

    private void Move()
    {
        _direction = _inputReader.Direction();

        _movement = new Vector2(_direction * _moveSpeed, _rigidbody.velocity.y);

        _rigidbody.velocity = _movement;
    }

    private void JumpAction()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }

    private void UpdateAnimator()
    {
        _animator.SetFloat(PlayerAnimatorData.Params.MoveX, Mathf.Abs(_direction));
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, _groundCheck.IsGrounded);
    }
}