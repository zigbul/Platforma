using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private GroundChecker _groundChecker;

    [SerializeField] private float _jumpForce = 10f;

    private void Update()
    {
        if (_inputHandler.JumpPressed && _groundChecker.CheckIsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
    }
}
