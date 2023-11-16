using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundRadius = 0.5f;

    private const string Leap = "Jump";
    private const string Speed = "Speed";
    private const string Horizontal = "Horizontal";

    private Animator _animator;
    private Vector2 _velocity;
    private Vector2 _direction;
    private bool _isForward;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody2D;
    private RaycastHit2D _hit;
    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _direction.x = Input.GetAxisRaw(Horizontal);

        _hit = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, _groundRadius, _groundLayer);

        if (_hit.collider != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }


        if (Input.GetKey(KeyCode.D))
        {
            _isForward = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _isForward = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _velocity = _rigidbody2D.velocity;
        _velocity.x = _direction.x * _speed * Time.deltaTime;
        _rigidbody2D.velocity = _velocity;

        _spriteRenderer.flipX = _isForward;

        _animator.SetFloat(Speed, Mathf.Abs(_direction.x));
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _isGrounded == true)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            _animator.SetTrigger(Leap);
        }
    }
}
