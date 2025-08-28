using UnityEngine;

public class Donut : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        gameObject.SetActive(false);
    }
}
