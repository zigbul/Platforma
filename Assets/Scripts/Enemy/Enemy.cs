using UnityEngine;

[RequireComponent(typeof(Mover), typeof(SpriteFlipper), typeof(Patroller))]
[RequireComponent(typeof(EnemyAnimator), typeof(Chaser), typeof(Damager))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private SpriteFlipper _spriteFlipper;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private Chaser _chaser;
    [SerializeField] private Damager _damager;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _spriteFlipper = GetComponent<SpriteFlipper>();
        _patroller = GetComponent<Patroller>();
        _animator = GetComponent<EnemyAnimator>();
        _chaser = GetComponent<Chaser>();
        _damager = GetComponent<Damager>();
        _health = GetComponent<Health>();
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
        if (_health.Current <= 0)
        {
            gameObject.SetActive(false);
        }

        if (_spriteFlipper.CanFlip)
        {
            _spriteFlipper.FlipSprite();
        }
    }
}
