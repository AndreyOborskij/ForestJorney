using UnityEngine;

public class Visualization : MonoBehaviour
{
    [SerializeField] private ChangerAbilityAnimations _changerAbilityAnimations;
    [SerializeField] private GameObject _vamp;

    public void Toggle(bool isActive)
    {
        _vamp.SetActive(isActive);
        _changerAbilityAnimations.UpdateAbility(isActive);
    }
}
