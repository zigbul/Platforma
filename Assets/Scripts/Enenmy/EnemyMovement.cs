using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform[] _waypoints;

    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _distanceToTarget = 0.1f;

    private int _currentIndex = 0;
    private Vector2 _direction;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var currentTarget = _waypoints[_currentIndex];

        _direction = currentTarget.position - transform.position;

        _rigidbody2D.linearVelocity = _direction.normalized * _speed;

        if (_direction.sqrMagnitude <= _distanceToTarget * _distanceToTarget)
        {
            ChangeTargetIndex();
        }

        SetupAnimatorIsMoving(true);
    }

    private void ChangeTargetIndex()
    {
        _currentIndex = ++_currentIndex % _waypoints.Length;
    }

    private void SetupAnimatorIsMoving(bool isMoving)
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsMoving, isMoving);
    }
}
