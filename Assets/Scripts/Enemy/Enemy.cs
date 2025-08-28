using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(SpriteFlipper), typeof(Patroller))]
[RequireComponent(typeof(EnemyAnimator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private SpriteFlipper _spriteFlipper;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private EnemyAnimator _animator;

    private void Awake()
    {
        _movement = GetComponent<EnemyMovement>();
        _spriteFlipper = GetComponent<SpriteFlipper>();
        _patroller = GetComponent<Patroller>();
        _animator = GetComponent<EnemyAnimator>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = _patroller.GetDirection(transform.position);

        if (direction != Vector2.zero)
        {
            _movement.Move(direction);
            _animator.SetAnimatorIsMoving(true);
        }
        else
        {
            _animator.SetAnimatorIsMoving(false);
        }
    }

    private void Update()
    {
        _spriteFlipper.Flip();
    }
}
