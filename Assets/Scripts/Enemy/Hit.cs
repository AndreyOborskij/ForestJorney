using System;
using System.Collections;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private HitZone _hitZone;

    public Action<int> DealtDamage;

    private Coroutine _action;
    private int _damage = 10;
    private float _refresh = 2f;
    private bool _isCome = false;

    private void OnEnable()
    {
        _hitZone.Comming += TakeDamage;
        _hitZone.Left += ReturnPatrol;
    }

    private void OnDisable()
    {
        _hitZone.Comming -= TakeDamage;
        _hitZone.Left -= ReturnPatrol;
    }

    private void TakeDamage()
    {
        _isCome = true;
        _action = StartCoroutine(Attack());
    }

    private void ReturnPatrol()
    {
        _isCome = false;

        if (_action != null)
        {
            StopCoroutine(_action);
        }
    }

    private IEnumerator Attack()
    {
        var wait = new WaitForSeconds(_refresh);

        if (_isCome == true)
        {
            DealtDamage?.Invoke(_damage);

            yield return wait;
        }
    }
}
