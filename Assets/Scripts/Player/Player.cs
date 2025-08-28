using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(SpriteFlipper), typeof(PlayerAnimator))]
[RequireComponent(typeof(InputHandler), typeof(Jumper), typeof(GroundChecker))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private SpriteFlipper _spriteFlipper;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAnimator _animator;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _spriteFlipper = GetComponent<SpriteFlipper>();
        _inputHandler = GetComponent<InputHandler>();
        _jumper = GetComponent<Jumper>();
        _groundChecker = GetComponent<GroundChecker>();
        _animator = GetComponent<PlayerAnimator>();
    }

    private void FixedUpdate()
    {
        if (_inputHandler.HorizontalInput != Vector2.zero.x)
        {
            _movement.Move(_inputHandler.HorizontalInput);
            _animator.SetIsMoving(true);
        }
        else
        {
            _animator.SetIsMoving(false);
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