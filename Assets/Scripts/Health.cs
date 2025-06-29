using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _maxValue = 100;
    private int _minValue = 0;

    public int CurrentValue { get; private set; }

    public event Action Damaged;
    public event Action Died;

    private void Start()
    {
        CurrentValue = _maxValue;
    }

    public void DecreaseValue(int damage)
    {
        if (damage < 0)
        {
            return;
        }

        CurrentValue = Mathf.Max(CurrentValue - damage, _minValue);        

        Damaged?.Invoke();

        if (CurrentValue <= _minValue)
        {
            Died?.Invoke();
        }
    }

    public void IncreaseValue(int heal)
    {
        if (heal < 0)
        {
            return;
        }

        CurrentValue = Mathf.Min(CurrentValue + heal, _maxValue);
    }
}
