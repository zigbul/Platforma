using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 10;
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
            _current -= damage;
        }
    }

    public void TakeHealth(int healthToRestore)
    {
        if (IsPositive(healthToRestore))
        {
            _current = Mathf.Min(_current + healthToRestore, _max);
        }
    }

    private bool IsPositive(int value)
    {
        return Mathf.Sign(value) > 0;
    }
}
