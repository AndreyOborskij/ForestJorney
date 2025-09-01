using System;
using System.Collections;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Coroutine _activeCorutine;
    private float _workTime = 6f;
    private float _refreshTime = 4f;
    private bool _canActive = true;
    private WaitForSeconds _work;
    private WaitForSeconds _refresh;

    public event Action<bool> Actived;
    public event Action<bool, float> Refreshed;

    private void Awake()
    {
        _work = new WaitForSeconds(_workTime);
        _refresh = new WaitForSeconds(_refreshTime);
    }

    private void OnEnable()
    {
        _inputReader.Interacted += HandleActivation;
    }

    private void OnDisable()
    {
        _inputReader.Interacted -= HandleActivation;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
    }

    private void HandleActivation(bool state)
    {
        SetState(state);
    }

    private void SetState(bool state)
    {
        if (state && _canActive && _activeCorutine == null)
        {
            _activeCorutine = StartCoroutine(AbilityDuration());
        }
    }

    private IEnumerator AbilityDuration()
    {
        Actived?.Invoke(_canActive);
        Refreshed?.Invoke(_canActive, _workTime);

        yield return _work;

        _canActive = false;
        Actived?.Invoke(_canActive);
        Refreshed?.Invoke(_canActive, _workTime);

        yield return _refresh;

        _canActive = true;
        _activeCorutine = null;
    }
}
