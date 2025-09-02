using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _cooldown = 1f;
    [SerializeField] private float _attackRange = 1.5f;

    [Header("Set Dynamically")]
    [SerializeField] private float lastAttackTime;
    [SerializeField] private bool _canAttack;
    [SerializeField] private Health _target;

    public bool CanAttack => _canAttack && Time.time > lastAttackTime + _cooldown;

    public void CanAttackTarget(Health target)
    {
        Vector2 direction = target.transform.position - transform.position;

        if (direction.sqrMagnitude <= _attackRange * _attackRange)
        {
            _canAttack = true;
            _target = target;
        }
        else
        {
            _canAttack = false;
            _target = null;
        }
    }

    public void Attack()
    {
        if (_target.Current <= 0)
        {
            _canAttack = false;
            return;
        }

        lastAttackTime = Time.time;
        _target.TakeDamage(_damage);
    }
}
