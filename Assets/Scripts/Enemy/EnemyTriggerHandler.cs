using UnityEngine;

public class EnemyTriggerHandler : MonoBehaviour
{
    [SerializeField] private Chaser _chaser;
    [SerializeField] private PlayerDetector _playerDetector;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
