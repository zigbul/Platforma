using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 10;
    [SerializeField] private int _min = -1;
    [SerializeField] private int _current;

    public int Current => _current;

    private void Start()
    {
        _current = _max;
    }

    public void TakeDamage(int damage)
    {
        if (IsPositive(damage))
        {
            _current = Mathf.Clamp(_current - damage, _min, _max);
        }
    }

    public void TakeHealth(int healthToRestore)
    {
        if (IsPositive(healthToRestore))
        {
            _current = Mathf.Clamp(_current + healthToRestore, _min, _max);
        }
    }

    private bool IsPositive(int value)
    {
        return Mathf.Sign(value) > 0;
    }
}
