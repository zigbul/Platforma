using UnityEngine;

[RequireComponent(typeof(Mover), typeof(SpriteFlipper), typeof(PlayerAnimator))]
[RequireComponent(typeof(InputHandler), typeof(Jumper), typeof(GroundChecker))]
[RequireComponent(typeof(Damager), typeof(Collector), typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private SpriteFlipper _spriteFlipper;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Damager _damager;
    [SerializeField] private Collector _collector;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _spriteFlipper = GetComponent<SpriteFlipper>();
        _inputHandler = GetComponent<InputHandler>();
        _jumper = GetComponent<Jumper>();
        _groundChecker = GetComponent<GroundChecker>();
        _animator = GetComponent<PlayerAnimator>();
        _damager = GetComponent<Damager>();
        _collector = GetComponent<Collector>();
        _health = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        if (_inputHandler.HorizontalInput != Vector2.zero.x)
        {
            _mover.Move(_inputHandler.HorizontalInput);
            _animator.ActivateMovingAnimation();
        }
        else
        {
            _animator.DeactivateMovingAnimation();
        }

        if (_damager.CanAttack)
        {
            _damager.Attack();
            _animator.SetIsAttacking();
        }
    }

    private void Update()
    {
        if (_health.Current <= 0)
        {
            gameObject.SetActive(false);
        }

        _spriteFlipper.Flip();

        if (_inputHandler.JumpPressed && _groundChecker.IsGrounded())
        {
            _jumper.Jump();
        }

        if (_collector.Donut != null)
        {
            _collector.Donut.Collect();
        }

        if (_collector.Potion != null)
        {
            int healthToRestore = _collector.Potion.GetHealthToRestore();
            _health.TakeHealth(healthToRestore);
        }

        _collector.RemoveItems();
    }
}