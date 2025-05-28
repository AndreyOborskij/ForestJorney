using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class BaseballBat : MonoBehaviour 
{
    [SerializeField] private ChangerBasebalBatAnimations _changerBasebalBatAnimations;
    [SerializeField] private InputReader _inputReader;

    private Collider2D _collider;
    private Coroutine _hit;
    private float _refreshHit = 2f;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
    }

    private void Update()
    {
        if (_inputReader.GetIsHit())
        {
            StartHit();
        }
    }

    private IEnumerator Hit()
    {
        Activate();
        _changerBasebalBatAnimations.UpdateHit();

        yield return new WaitForSeconds(_refreshHit);
        Deactivate();
    }

    private void StartHit()
    {
        if (_hit != null)
        {
            StopCoroutine(_hit);
        }

        _hit = StartCoroutine(Hit());
    }

    private void Activate()
    {
        _collider.enabled = true;
    }

    private void Deactivate()
    {
        _collider.enabled = false;
        StopCoroutine(_hit);
    }
}

