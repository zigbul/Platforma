using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpriteFlipper : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private bool _isFacingRight = true;

    private float _flipThreshold = 0.01f;
    private float _facingRightRotation = 0f;
    private float _facingLeftRotation = 180f;

    public void Flip()
    {
        if (_rigidbody.linearVelocity.x > _flipThreshold && _isFacingRight == false)
        {
            FlipSprite();
        }
        else if (_rigidbody.linearVelocity.x < -_flipThreshold && _isFacingRight)
        {
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        _isFacingRight = !_isFacingRight;

        Vector2 rotation = transform.eulerAngles;

        rotation.y = rotation.y == _facingLeftRotation
            ? _facingRightRotation 
            : _facingLeftRotation;

        transform.eulerAngles = rotation;
    }
}
