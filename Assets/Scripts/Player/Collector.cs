using UnityEngine;

public class Collector : MonoBehaviour
{
    private Potion _potion;

    public Potion Potion => _potion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Donut donut))
        {
            donut.Collect();
        }

        if (collision.collider.TryGetComponent(out Potion potion))
        {
            _potion = potion;
            _potion.OnCollect += RemovePotion;
        }
    }

    private void RemovePotion()
    {
        _potion.OnCollect -= RemovePotion;
        _potion.gameObject.SetActive(false);
        _potion = null;
    }
}
