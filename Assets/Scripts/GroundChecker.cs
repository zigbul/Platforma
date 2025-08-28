using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;

    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _extraHeight = 0.1f;

    public bool CheckIsGrounded()
    {
        Bounds bounds = _collider.bounds;
        float rotationAngle = 0f;

        RaycastHit2D hit = Physics2D.BoxCast(bounds.center, bounds.size, rotationAngle, Vector2.down, _extraHeight, _groundMask);

        return hit.collider != null;
    }
}
