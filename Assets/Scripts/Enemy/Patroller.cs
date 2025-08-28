using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _distanceToTarget = 0.1f;

    private int _currentIndex = 0;

    public Vector2 GetDirection(Vector2 currentPosition)
    {
        if (_waypoints.Length == 0)
            return Vector2.zero;

        Vector2 targetPosition = _waypoints[_currentIndex].position;
        Vector2 direction = targetPosition - currentPosition;

        if (direction.sqrMagnitude <= _distanceToTarget * _distanceToTarget)
        {
            _currentIndex = ++_currentIndex % _waypoints.Length;
        }

        return direction;
    }
}
