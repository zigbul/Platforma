using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeed = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalDierection)
    {
        _rigidbody.linearVelocity = new Vector2(horizontalDierection * _moveSpeed, _rigidbody.linearVelocity.y);
    }
}
