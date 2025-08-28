using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeed = 5f;

    public void Move(float horizontalInput)
    {
        _rigidbody.linearVelocity = new Vector2(horizontalInput * _moveSpeed, _rigidbody.linearVelocity.y);
    }
}
