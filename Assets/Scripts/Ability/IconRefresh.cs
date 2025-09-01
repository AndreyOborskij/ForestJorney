using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IconRefresh : MonoBehaviour
{
    [SerializeField] private Image _iconAbility;
    [SerializeField] private Ability _ability;

    private Coroutine _avtiveCoroutine;
    private float _fillPrecent = 1f;

    private void OnEnable()
    {
        _ability.Refreshed += DrawFillRoutine;
    }

    private void OnDisable()
    {
        _ability.Refreshed -= DrawFillRoutine;
    }

    private void DrawFillRoutine(bool isActive, float time)
    {
        if (_avtiveCoroutine != null)
            StopCoroutine(_avtiveCoroutine);

        _avtiveCoroutine = StartCoroutine(FillRoutine(isActive, time));
    }

    private IEnumerator FillRoutine(bool isActive, float time)
    {
        float timer = 0;

        while (timer < time)
        {
            timer += Time.deltaTime;

            _iconAbility.fillAmount = CalculateFillAmount(isActive, timer, time);

            yield return null;
        }

        _avtiveCoroutine = null;
    }

    private float CalculateFillAmount(bool isActive, float timer, float time)
    {
        return isActive ? _fillPrecent - (timer / time) : timer / time;
    }
}