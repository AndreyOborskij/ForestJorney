using UnityEngine;

public class Health : MonoBehaviour
{
    private int _maxValue = 100;
    private int _minValue = 0;
    private int _currentValue = 100;

    public int CurrentValue => _currentValue;

    public void DecreaseValue(int damage)
    {
        if (damage < 0) 
        {            
            return;
        }

        _currentValue = Mathf.Max(_currentValue - damage, _minValue);
    }

    public void IncreaseValue(int heal)
    {
        if (heal < 0)
        {
            return;
        }

        _currentValue = Mathf.Min(_currentValue + heal, _maxValue);
    }
}
