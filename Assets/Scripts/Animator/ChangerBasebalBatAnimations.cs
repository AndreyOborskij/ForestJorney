using UnityEngine;

public class ChangerBasebalBatAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private BaseballBat _baseballBat; 
    [SerializeField] private InputReader _inputReader;

    private int _renderLayer = 0;

    private void Update()
    {
        if (_inputReader.GetIsHit())
        {
            _baseballBat.Activate();
            _animator.SetTrigger(BaseballBatAnimatorData.Params.Hit);
        }

        if (_baseballBat.gameObject.activeSelf == true && IsAnimationDone() == true)
        {
            _baseballBat.Deactivate();
        }
    }

    private bool IsAnimationDone()
    {
        return _animator.GetCurrentAnimatorStateInfo(_renderLayer).normalizedTime >= 1f;
    }
}
