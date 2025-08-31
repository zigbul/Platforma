using UnityEngine;

public class Potion : MonoBehaviour, ICollectable
{
    [SerializeField] private int _healthToRestore = 5;

    public void Collect(Health health)
    {
        health.Heal(_healthToRestore);
        gameObject.SetActive(false);
    }
}
