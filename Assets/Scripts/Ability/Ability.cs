using System.Collections;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private IconRefresh _iconRefresh;
    [SerializeField] private Visualization _visualization;
    [SerializeField] private InputReader _inputReader;

    private Coroutine _activeCorutine;
    private float _workTime = 6f;
    private float _refreshTime = 4f;
    private bool _canActive = true;

    private void OnEnable()
    {
        _inputReader.Interacted += HandleActivation;
    }

    private void OnDisable()
    {
        _inputReader.Interacted += HandleActivation;
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
    }

    private void HandleActivation(bool state)
    {
        SetState(state);
    }

    private void SetState(bool state)
    {
        if (_canActive == true && state == true)
        {
            if (_activeCorutine != null)
            {
                StopCoroutine(AbilityDuration());
            }

            _activeCorutine = StartCoroutine(AbilityDuration());
        }
    }

    private IEnumerator AbilityDuration()
    {
        _visualization.Toggle(_canActive);
        _iconRefresh.DrawFillRoutine(_workTime, _canActive);

        yield return new WaitForSeconds(_workTime);

        _canActive = false;
        _visualization.Toggle(_canActive);
        _iconRefresh.DrawFillRoutine(_refreshTime, _canActive);

        yield return new WaitForSeconds(_refreshTime);

        _canActive = true;
    }
}
