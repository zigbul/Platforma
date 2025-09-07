using UnityEngine;

public class Potion : MonoBehaviour, ICollectable
{
    [SerializeField] private int _healthToRestore = 5;

    public void Collect()
    {
    }

    public int GetHealthToRestore()
    {
        Collect();
        return _healthToRestore;
    }    
}
