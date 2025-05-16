using UnityEngine;

public class Healthbar : MonoBehaviour
{
    private int _maxValue = 100;
    private int _minValue = 0;
    private int _currentValue = 100;

    public int CurrentValue => _currentValue;

    public void DecreaseValue(int damage)
    {
        if (_currentValue - damage < _minValue)
        {
            _currentValue = _minValue;
        }
        else
        {
            _currentValue -= damage;
        }
    }

    public void IncreaseValue(int heal)
    {
        if (_currentValue + heal > _maxValue)
        {
            _currentValue = _maxValue;
        }
        else
        {
            _currentValue += heal;
        }
    }
}
