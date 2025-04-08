using UnityEngine;

public class ChangerPlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundCheck;
    [SerializeField] private AttackChecker _attakChecker;

    private void Update()
    {
        UpdateAnimations(_inputReader.Direction, _groundCheck.IsGrounded, _attakChecker.IsAttacked);
    }

    public void UpdateAnimations(float speed, bool isJump, bool isAttacked)
    {
        _animator.SetFloat(PlayerAnimatorData.Params.MoveX, Mathf.Abs(speed));
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, isJump);
        _animator.SetBool(PlayerAnimatorData.Params.IsAttacked, isAttacked);
    }
}