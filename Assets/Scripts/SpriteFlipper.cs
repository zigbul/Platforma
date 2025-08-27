using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpriteFlipper : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private bool _isFacingRight = true;

    private void FixedUpdate()
    {
        Flip();
    }

    private void Flip()
    {
        if (_rigidbody.linearVelocity.x > 0.01f && _isFacingRight == false)
        {
            FlipSprite();
        }
        else if (_rigidbody.linearVelocity.x < -0.01f && _isFacingRight)
        {
            FlipSprite();
        }
    }
    private void FlipSprite()
    {
        _isFacingRight = !_isFacingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
