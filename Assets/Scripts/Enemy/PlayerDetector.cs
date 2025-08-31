using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Chaser _chaser;
    [SerializeField] private Damager _damager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _chaser.StartChasing(player);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health player))
        {
            _damager.CanAttackTarget(player);
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
