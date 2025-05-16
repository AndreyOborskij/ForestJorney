using UnityEngine;

public class ChangerPlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void UpdateMovement(float speed)
    {
        _animator.SetFloat(PlayerAnimatorData.Params.MoveX, Mathf.Abs(speed));
    }

    public void UpdateJump(bool isJump)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, isJump);
    }

    public void UpdateTakeDamage(bool isAttacked)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsAttacked, isAttacked);
    }
}