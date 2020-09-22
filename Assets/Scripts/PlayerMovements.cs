using System;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public enum Direction
    {
        Right,
        Left,
    };
    
    [Header("Speeds")]
    public float speed;
    public float jumpForce;

    [Header("Ground checking")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask layerMask;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _horizontalMovement;
    private Vector3 _velocity = Vector3.zero;
    private bool _isJumping = false;
    private bool _isGrounded;
    private Direction _direction = Direction.Right;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal") * speed;

        if (_isGrounded && !_isJumping && Input.GetButtonDown("Jump"))
        {
            _isJumping = true;
        }

        ComputeDirection();
        _animator.SetFloat("speed", Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetFloat("verticalSpeed", _rigidbody.velocity.y);
    }

    private void FixedUpdate()
    {
        var rigidbodyVelocity = _rigidbody.velocity;
        Vector3 velocity = new Vector2(_horizontalMovement, rigidbodyVelocity.y);
        _rigidbody.velocity = Vector3.SmoothDamp(rigidbodyVelocity, velocity, ref _velocity, .05f);

        _isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, layerMask);
        
        if (_isJumping)
        {
            var force = new Vector2(0, jumpForce);
            _rigidbody.AddForce(force);
            _isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
    }

    private void ComputeDirection()
    {
        if (_rigidbody.velocity.x > 0.1f)
        {
            _spriteRenderer.flipX = false;
            _direction = Direction.Right;
        }
        else if (_rigidbody.velocity.x < -0.1f)
        {
            _spriteRenderer.flipX = true;
            _direction = Direction.Left;
        }
    }

    public Direction GetDirection()
    {
        return _direction;
    }
}
