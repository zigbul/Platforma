using UnityEngine;

[RequireComponent(typeof(Mover), typeof(SpriteFlipper), typeof(Patroller))]
[RequireComponent(typeof(EnemyAnimator), typeof(Chaser))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private SpriteFlipper _spriteFlipper;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private Chaser _chaser;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _spriteFlipper = GetComponent<SpriteFlipper>();
        _patroller = GetComponent<Patroller>();
        _animator = GetComponent<EnemyAnimator>();
        _chaser = GetComponent<Chaser>();
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
    }

    private void Update()
    {
        _spriteFlipper.Flip();
    }
}
