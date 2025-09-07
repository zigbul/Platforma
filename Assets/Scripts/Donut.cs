using System;
using UnityEngine;

public class Donut : MonoBehaviour, ICollectable
{
    public event Action<Donut> OnReturnToPool;

    public void Collect()
    {
        OnReturnToPool?.Invoke(this);
    }
}
