using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private HitZone _hitZone;

    public Action<float> AttackedDamage; 
    public Action StoppedDamage;

    private Coroutine _action;
    private float _damage = 10;
    private float _refresh = 1f;
    private bool _isCome = false;

    private void OnEnable()
    {
        _hitZone.Comming += Strike;
        _hitZone.Left += StopStrike;
    }

    private void OnDisable()
    {
        _hitZone.Comming -= Strike;
        _hitZone.Left -= StopStrike;
    }

    private void Strike()
    {
        _isCome = true;
        _action = StartCoroutine(Attack());
    }

    private void StopStrike()
    {
        _isCome = false;
        
        StoppedDamage?.Invoke();

        if (_action != null)
        {
            StopCoroutine(_action);
        }
    }

    private IEnumerator Attack()
    {
        var wait = new WaitForSeconds(_refresh);

        while (_isCome == true)
        {
            AttackedDamage?.Invoke(_damage);

            yield return wait;
        }
    }
}
