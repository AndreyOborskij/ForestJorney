using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IconRefresh : MonoBehaviour
{
    [SerializeField] private Image _ability;

    private Coroutine _avtiveCoroutine;
    private float _fillPrecent = 1f;

    public void DrawFillRoutine(float workTime, bool isActive)
    {
        if (_avtiveCoroutine != null)
            StopCoroutine(FillRoutine(workTime, isActive));

        _avtiveCoroutine = StartCoroutine(FillRoutine(workTime, isActive));
    }

    private IEnumerator FillRoutine(float time, bool isActive)
    {
        float timer = 0;

        while (timer < time)
        {
            timer += Time.deltaTime;

            if (isActive == true)
                _ability.fillAmount = _fillPrecent - (timer / time);
            else
                _ability.fillAmount = timer / time;

            yield return null;
        }
    }
}