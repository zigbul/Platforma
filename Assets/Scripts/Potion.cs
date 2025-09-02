using UnityEngine;

public class Potion : MonoBehaviour, ICollectable
{
    [SerializeField] private int _healthToRestore = 5;

    public int GetHealthToRestore()
    {
        Deactivate();
        return _healthToRestore;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
