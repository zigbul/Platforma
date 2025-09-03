using UnityEngine;

public class Chaser : MonoBehaviour
{
    private bool _isChasing = false;
    private Vector3 _playerPosition;

    public bool IsChasing => _isChasing;

    public float HorizontalDirection
    {
        get
        {
            if (_playerPosition == Vector3.zero)
            {
                _isChasing = false;
                return Vector3.zero.x;
            }

            Vector3 direction = _playerPosition - transform.position;
            direction.Normalize();

            return direction.x;
        }
    }

    public void StartChasing(Vector3 playerPosition)
    {
        _isChasing = true;
        _playerPosition = playerPosition;
    }

    public void StopChasing()
    {
        _isChasing = false;
        _playerPosition = Vector3.zero;
    }
}
