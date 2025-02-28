using UnityEngine;

public class ChangerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundCheck;

    private void Update()
    {
        UpdateAnimations(_inputReader.Direction, _groundCheck.IsGrounded);
    }

    public void UpdateAnimations(float speed, bool isJump)
    {
        _animator.SetFloat(PlayerAnimatorData.Params.MoveX, Mathf.Abs(speed));
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, isJump);
    }
}