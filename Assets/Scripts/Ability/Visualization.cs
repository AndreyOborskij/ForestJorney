using UnityEngine;
using UnityEngine.UI;

public class Visualization : MonoBehaviour
{
    [SerializeField] private ChangerAbilityAnimations _changerAbilityAnimations;
    [SerializeField] private LifeSteal _vampireAbility;
    [SerializeField] private Ability _ability;

    private void OnEnable()
    {
        _ability.Actived += Toggle;
    }

    private void OnDisable()
    {
        _ability.Actived -= Toggle;
    }

    private void Toggle(bool isActive)
    {
        _vampireAbility.gameObject.SetActive(isActive);
        _changerAbilityAnimations.UpdateAbility(isActive);
    }
}
