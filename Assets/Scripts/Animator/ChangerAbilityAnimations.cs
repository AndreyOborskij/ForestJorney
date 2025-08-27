using UnityEngine;

public class ChangerAbilityAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void UpdateAbility(bool isStealLife)
    {
        _animator.SetBool(AbilityAnimatorData.Params.IsStealLife, isStealLife);
    }
}
