using System;
using System.Collections;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Coroutine _activeCoroutine;
    private float _workTime = 6f;
    private float _refreshTime = 4f;
    private bool _canActive = true;
    private WaitForSeconds _abilityDurationWait;
    private WaitForSeconds _cooldownWait;

    public event Action<bool> Actived;
    public event Action<bool, float> Refreshed;

    private void Awake()
    {
        _abilityDurationWait = new WaitForSeconds(_workTime);
        _cooldownWait = new WaitForSeconds(_refreshTime);
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

    private void HandleActivation()
    {
        SetState();
    }

    private void SetState()
    {
        if ( _canActive && _activeCoroutine == null)
        {
            _activeCoroutine = StartCoroutine(Activate());
        }
    }

    private IEnumerator Activate()
    {
        Actived?.Invoke(_canActive);
        Refreshed?.Invoke(_canActive, _workTime);

        yield return _abilityDurationWait;

        _canActive = false;
        Actived?.Invoke(_canActive);
        Refreshed?.Invoke(_canActive, _workTime);

        yield return _cooldownWait;

        _canActive = true;
        _activeCoroutine = null;
    }
}
