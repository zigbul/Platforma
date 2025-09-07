using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ActivateMovingAnimation()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, true);
    }

    public void DeactivateMovingAnimation()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, false);
    }

    public void SetIsAttacking()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.IsAttacking);
    }
}
