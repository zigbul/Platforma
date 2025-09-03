using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 10;
    [SerializeField] private int _current;

    public int Current => _current;

    private void Start()
    {
        _current = _max;
    }

    public void TakeDamage(int damage)
    {
        _current -= Mathf.Abs(damage);
    }

    public void TakeHealth(int healthToRestore)
    {
        _current = Mathf.Min(_current + Mathf.Abs(healthToRestore), _max);
    }
}
