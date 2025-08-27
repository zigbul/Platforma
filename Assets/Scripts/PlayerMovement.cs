using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Animator _animator;

    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _extraHeight = 0.1f;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 12f;
    
    private float _inputX;

    private void Update()
    {
        _inputX = Input.GetAxis(Horizontal);

        if (Input.GetButtonDown("Jump") && CheckIsGrounded())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (_inputX != 0)
        {
            Move();
            _animator.SetBool(nameof(Move), true);
        }
        else
        {
            _animator.SetBool(nameof(Move), false);
        }
    }

    private void Move()
    {
        _rigidbody.linearVelocity = new Vector2(_inputX * _moveSpeed, _rigidbody.linearVelocity.y);
    }

    private void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
    }

    private bool CheckIsGrounded()
    {
        Bounds bounds = _collider.bounds;
        float rotationAngle = 0f;

        RaycastHit2D hit = Physics2D.BoxCast(bounds.center, bounds.size, rotationAngle, Vector2.down, _extraHeight, _groundMask);

        return hit.collider != null;
    }
}
