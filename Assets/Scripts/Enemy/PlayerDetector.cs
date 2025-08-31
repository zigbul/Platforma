using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Chaser _chaser;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _chaser.StartChasing(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _))
        {
            _chaser.StopChasing();
        }
    }
}
