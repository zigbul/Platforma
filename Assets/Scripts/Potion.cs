using System;
using UnityEngine;

public class Potion : MonoBehaviour, ICollectable
{
    [SerializeField] private int _healthToRestore = 5;

    public int HealthRestore => _healthToRestore;

    public event Action OnCollect;

    public void Collect()
    {
        OnCollect?.Invoke();
    }  
}
