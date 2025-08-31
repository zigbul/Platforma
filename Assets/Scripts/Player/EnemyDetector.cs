using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private Damager _damager;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health player))
        {
            _damager.CanAttackTarget(player);
        }
    }
}
