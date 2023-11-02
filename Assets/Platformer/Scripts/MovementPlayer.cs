using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundRadius = 0.5f;

    private const string Jump = "Jump";
    private const string Speed = "Speed";

    private Animator _animator;
    private float _direction;
    private bool _isForward;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody2D;
    private RaycastHit2D _hit;
    private SpriteRenderer _spriteRenderer;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _direction = Input.GetAxisRaw("Horizontal");

        _hit = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, _groundRadius, _groundLayer);

        if (_hit.collider != null)
        {
            _isGrounded = false;
        }
        else
        {
            _isGrounded = true;
        }


        if (Input.GetKey(KeyCode.D))
        {
            _isForward = false;
            Move(_direction, _isForward);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _isForward = true;
            Move(_direction, _isForward);
        }

        if (Input.GetKey(KeyCode.Space) && _isGrounded == false)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            _animator.SetTrigger(Jump);
        }

        if (_direction == 0)
        {
            _animator.SetFloat(Speed, _direction);
        }
    }

    private void Move(float direction, bool isForward)
    {
        transform.Translate(direction * _speed * Time.deltaTime, 0, 0);
        _spriteRenderer.flipX = isForward;
        _animator.SetFloat(Speed, Mathf.Abs(direction));
    }
}
