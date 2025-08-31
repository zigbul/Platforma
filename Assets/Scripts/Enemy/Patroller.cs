using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _distanceToTarget = 0.1f;

    private int _currentIndex = 0;

    public float GetHorizontalDirection()
    {
        if (_waypoints.Length == 0)
            return Vector2.zero.x;

        Vector2 targetPosition = _waypoints[_currentIndex].position;
        Vector2 direction = targetPosition - (Vector2)transform.position;

        if (direction.sqrMagnitude <= _distanceToTarget * _distanceToTarget)
        {
            _currentIndex = ++_currentIndex % _waypoints.Length;
        }

        direction.Normalize();

        return direction.x;
    }
}
