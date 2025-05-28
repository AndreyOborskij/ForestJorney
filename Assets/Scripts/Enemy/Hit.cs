using System.Collections;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private HitZone _hitZone;

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

    private void TakeDamage(Player player)
    {
        _isCome = true;
        _action = StartCoroutine(Attack(player));
    }

    private void ReturnPatrol()
    {
        _isCome = false;

        if (_action != null)
        {
            StopCoroutine(_action);
        }
    }

    private IEnumerator Attack(Player player)
    {
        var wait = new WaitForSeconds(_refresh);

        if (_isCome == true)
        {
            player.TakeDamage(_damage);

            yield return wait;
        }
    }
}
