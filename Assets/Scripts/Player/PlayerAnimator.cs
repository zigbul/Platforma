using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetIsMoving(bool isMoving)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, isMoving);
    }

    public void SetIsAttacking()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.IsAttacking);
    }
}
