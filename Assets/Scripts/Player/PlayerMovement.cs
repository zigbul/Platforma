using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
[RequireComponent(typeof(InputHandler), typeof(Jumper))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private InputHandler _inputHandler;

    [SerializeField] private float _moveSpeed = 5f;

    private void FixedUpdate()
    {
        if (_inputHandler.HorizontalInput != Vector2.zero.x)
        {
            Move();
        }
        else
        {
            SetupAnimatorIsMoving(false);
        }
    }

    private void Move()
    {
        _rigidbody.linearVelocity = new Vector2(_inputHandler.HorizontalInput * _moveSpeed, _rigidbody.linearVelocity.y);
        SetupAnimatorIsMoving(true);
    }

    private void SetupAnimatorIsMoving(bool isMoving)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, isMoving);
    }
}
