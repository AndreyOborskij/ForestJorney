using UnityEngine;

public class Healthbar : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _health = 100;

    public int Health => _health;

    public void DecreaseValue(int damage)
    {
        if (_health - damage < _minHealth)
        {
            _health = _minHealth;
        }
        else
        {
            _health -= damage;
        }
    }

    public void IncreaseValue(int health)
    {
        if (_health + health > _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health += health;
        }
    }
}
