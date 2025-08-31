using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out ICollectable donut))
        {
            donut.Collect(_health);
        }

        if (collision.collider.TryGetComponent(out ICollectable potion))
        {
            potion.Collect(_health);
            
        }
    }
}
