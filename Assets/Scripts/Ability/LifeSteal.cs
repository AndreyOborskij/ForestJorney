using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSteal : MonoBehaviour
{
    public DistanceMeasurer _distanceMeasurer;

    private Coroutine _activeCoroutine;
    private float _stealPower = 15f;
    private float _responseTime = 1f;
    private List<Enemy> _enemies = new List<Enemy>();
    private Enemy _nearestEnemy;

    public event Action<float> Stole;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemies.Add(enemy);

            FindNearestEnemy();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemies.Remove(enemy);

            if (enemy == _nearestEnemy)
            {
                FindNearestEnemy();
            }
        }
    }

    private void FindNearestEnemy()
    {
        _nearestEnemy = _distanceMeasurer.DetermineNearestEnemy(_enemies);

        Steal(_nearestEnemy);
    }

    private void Steal(Enemy enemy)
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _activeCoroutine = StartCoroutine(Respond(enemy));
    }

    private IEnumerator Respond(Enemy enemy)
    {
        var wait = new WaitForSeconds(_responseTime);

        while (enemy != null)
        {
            enemy.LoseHealth(_stealPower);
            Stole?.Invoke(_stealPower);

            yield return wait;
        }
    }
}
