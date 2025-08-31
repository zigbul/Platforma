using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _cooldown = 1f;
    [SerializeField] private float _attackRange = 1.5f;

    [Header("Set Dynamically")]
    [SerializeField] private float lastAttackTime;
    [SerializeField] private bool _canAttack;
    [SerializeField] private Health _player;

    public bool CanAttack => _canAttack && Time.time > lastAttackTime + _cooldown;

    public void CanAttackTarget(Health player)
    {
        Vector2 direction = player.transform.position - transform.position;

        if (direction.sqrMagnitude <= _attackRange * _attackRange)
        {
            _canAttack = true;
            _player = player;
        }
        else
        {
            _canAttack = false;
            _player = null;
        }
    }

    public void Attack()
    {
        if (_player.CurrentHealth <= 0)
        {
            _canAttack = false;
            return;
        }

        lastAttackTime = Time.time;
        _player.TakeDamage(_damage);
    }
}
