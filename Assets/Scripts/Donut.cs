using UnityEngine;

public class Donut : MonoBehaviour, ICollectable
{
    public void Collect(Health health)
    {
        gameObject.SetActive(false);
    }
}
