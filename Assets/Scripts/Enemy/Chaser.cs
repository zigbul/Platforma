using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private bool _isChasing = false;
    [SerializeField] private Player _player;

    public bool IsChasing => _isChasing;

    public float HorizontalDirection
    {
        get
        {
            if (_player == null)
            {
                _isChasing = false;
                return Vector2.zero.x;
            }

            Vector2 direction = _player.transform.position - transform.position;
            direction.Normalize();

            return direction.x;
        }
    }

    public void StartChasing(Player player)
    {
        _isChasing = true;
        _player = player;
    }

    public void StopChasing()
    {
        _isChasing = false;
        _player = null;
    }
}
