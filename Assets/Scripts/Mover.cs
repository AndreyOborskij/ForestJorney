using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = "Jump"; 

    [SerializeField] private float jumpForce; 
    [SerializeField] private float moveSpeed;

    private Animator _moveX;
    private Animator _grounded;
    private Vector2 _movement;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody; 
    private bool _isGrounded;
    private float _horizontalInput;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _moveX = GetComponent<Animator>();
        _grounded = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Flip();

        if (Input.GetButtonDown(Jump) && _isGrounded)
        {
            JumpAction();
        }
    }

    private void Move()
    {
        _horizontalInput = Input.GetAxis(Horizontal);

        _moveX.SetFloat("moveX", Mathf.Abs(_horizontalInput));

        _movement = new Vector2(_horizontalInput * moveSpeed, _rigidbody.velocity.y);

        _rigidbody.velocity = _movement;
    }

    private void JumpAction()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
    }

    private void Flip()
    {
        if (_horizontalInput > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_horizontalInput < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Map map))
        {
            _isGrounded = true;
            _grounded.SetBool("isGrounded", _isGrounded);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Map map))
        {
            _isGrounded = false;
            _grounded.SetBool("isGrounded", _isGrounded);
        }
    }
}