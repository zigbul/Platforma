using UnityEngine;

[RequireComponent(typeof(Mover), typeof(SpriteFlipper), typeof(PlayerAnimator))]
[RequireComponent(typeof(InputHandler), typeof(Jumper), typeof(GroundChecker))]
[RequireComponent(typeof(Damager))]
public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private SpriteFlipper _spriteFlipper;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Damager _damager;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _spriteFlipper = GetComponent<SpriteFlipper>();
        _inputHandler = GetComponent<InputHandler>();
        _jumper = GetComponent<Jumper>();
        _groundChecker = GetComponent<GroundChecker>();
        _animator = GetComponent<PlayerAnimator>();
        _damager = GetComponent<Damager>();
    }

    private void FixedUpdate()
    {
        if (_inputHandler.HorizontalInput != Vector2.zero.x)
        {
            _mover.Move(_inputHandler.HorizontalInput);
            _animator.SetIsMoving(true);
        }
        else
        {
            _animator.SetIsMoving(false);
        }

        if (_damager.CanAttack)
        {
            _damager.Attack();
            _animator.SetIsAttacking();
        }
    }

    private void Update()
    {
        _spriteFlipper.Flip();

        if (_inputHandler.JumpPressed && _groundChecker.CheckIsGrounded())
        {
            _jumper.Jump();
        }
    }
}