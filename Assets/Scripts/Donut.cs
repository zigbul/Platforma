using UnityEngine;

public class Donut : MonoBehaviour, Collectable
{
    public void Collect()
    {
        gameObject.SetActive(false);
    }
}
