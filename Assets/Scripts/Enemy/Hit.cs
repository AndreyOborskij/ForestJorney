using System;
using System.Collections;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private HitZone _hitZone;

    public Action<int> DealtDamage; //DEAL неправильный глагол прошедшее время DEALT
    public Action StoppedDamage;

    private Coroutine _action;
    private int _damage = 10;
    private float _refresh = 2f;
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

        if (_isCome == true)
        {
            DealtDamage?.Invoke(_damage);

            yield return wait;
        }
    }
}
