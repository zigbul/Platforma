using UnityEngine;

public class CollectablePicker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Collectable item))
        {
            item.Collect();
        }
    }
}
