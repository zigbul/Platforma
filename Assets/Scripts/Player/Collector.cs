using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Donut _donut;
    [SerializeField] private Potion _potion;

    public Donut Donut => _donut;

    public Potion Potion => _potion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Donut donut))
        {
            _donut = donut;
        }

        if (collision.collider.TryGetComponent(out Potion potion))
        {
            _potion = potion;
        }
    }

    public void RemoveItems()
    {
        _donut = null;
        _potion = null;
    }
}
