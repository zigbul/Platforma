using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimatorIsMoving(bool isMoving)
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsMoving, isMoving);
    }

    public void SetAnimatorIsAttacking()
    {
        _animator.SetTrigger(EnemyAnimatorData.Params.IsAttacking);
    }
}
