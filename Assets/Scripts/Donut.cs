using UnityEngine;

public class Donut : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement _))
        {
            Destroy(gameObject);
        }
    }
}
