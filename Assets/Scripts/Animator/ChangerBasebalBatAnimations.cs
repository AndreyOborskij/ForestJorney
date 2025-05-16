using UnityEngine;

public class ChangerBasebalBatAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void UpdateHit()
    {
        _animator.SetTrigger(BaseballBatAnimatorData.Params.Hit);
    }    
}
