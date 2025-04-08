using UnityEngine;

public static class PlayerAnimatorData 
{
    public static class Params
    {
        public static readonly int MoveX = Animator.StringToHash("moveX");
        public static readonly int IsGrounded = Animator.StringToHash("isGrounded");
        public static readonly int IsAttacked = Animator.StringToHash("isAttacked");
    }
}
