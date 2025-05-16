using System.Collections;
using UnityEngine;

public class BaseballBat : MonoBehaviour 
{
    [SerializeField] private ChangerBasebalBatAnimations _changerBasebalBatAnimations;
    [SerializeField] private InputReader _inputReader;

    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
    }

    private void Update()
    {
        if (_inputReader.GetIsHit())
        {
            StartCoroutine(Hit());
        }
    }

    private IEnumerator Hit()
    {
        Activate();
        _changerBasebalBatAnimations.UpdateHit();

        yield return new WaitForSeconds(2f);
        Deactivate();
    }

    private void Activate()
    {
        _collider.enabled = true;
    }

    private void Deactivate()
    {
        _collider.enabled = false;
    }
}

