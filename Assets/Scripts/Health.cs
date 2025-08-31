using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private int _currentHealth;

    public int CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int health)
    {
        _currentHealth = Mathf.Min(_currentHealth +  health, _maxHealth);
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
