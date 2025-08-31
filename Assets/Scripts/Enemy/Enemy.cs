using UnityEngine;

[RequireComponent(typeof(Mover), typeof(SpriteFlipper), typeof(Patroller))]
[RequireComponent(typeof(EnemyAnimator), typeof(Chaser), typeof(Damager))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private SpriteFlipper _spriteFlipper;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private Chaser _chaser;
    [SerializeField] private Damager _damager;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _spriteFlipper = GetComponent<SpriteFlipper>();
        _patroller = GetComponent<Patroller>();
        _animator = GetComponent<EnemyAnimator>();
        _chaser = GetComponent<Chaser>();
        _damager = GetComponent<Damager>();
    }

    private void FixedUpdate()
    {
        float horizontalDirection;
        
        if (_chaser.IsChasing)
        {
            horizontalDirection = _chaser.HorizontalDirection;
        }
        else
        {
            horizontalDirection = _patroller.GetHorizontalDirection();
        }

        if (horizontalDirection != Vector2.zero.x)
        {
            _mover.Move(horizontalDirection);
            _animator.SetAnimatorIsMoving(true);
        }
        else
        {
            _animator.SetAnimatorIsMoving(false);
        }

        if (_damager.CanAttack)
        {
            _damager.Attack();
            _animator.SetAnimatorIsAttacking();
        }
    }

    private void Update()
    {
        _spriteFlipper.Flip();
    }
}
