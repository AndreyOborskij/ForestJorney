using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    public event Action<bool> Interacted;

    private bool _isJump;
    private bool _isHit;
    private int _hit = 0;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetButtonDown(Jump))
            _isJump = true;

        if (Input.GetMouseButtonDown(_hit))
            _isHit = true;

        if (Input.GetKeyDown(KeyCode.F))
            Interacted?.Invoke(true);
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);
    public bool GetIsHit() => GetBoolAsTrigger(ref _isHit);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;

        return localValue;
    }
}