using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderSlowBar : Bar
{
    [SerializeField] private Slider _slider;

    private Coroutine _coroutine;
    private float _smoothSpeed = 5f;

    protected override void OutputInfo()
    {
        float targetValue = Health.CurrentValue / Health.MaxValume;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(PaintVolume(targetValue));
    }

    private IEnumerator PaintVolume(float targetValue)
    {
        float progress = 0f;
        float startValue = _slider.value;

        while (startValue != targetValue)
        {
            progress += Time.deltaTime * _smoothSpeed;
            _slider.value = Mathf.Lerp(startValue, targetValue, progress);
            yield return null;
        }

        _slider.value = targetValue;
        _coroutine = null;
    }
}
