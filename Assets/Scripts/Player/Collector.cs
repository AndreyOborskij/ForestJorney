using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action Took; 
    public event Action<float> Healed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out ItemObject item))
        {
            if (item is Coin coin)
            {
                coin.Collect();
                Took?.Invoke();
            }
            else if (item is Heart heart)
            {
                heart.Collect();
                Healed?.Invoke(heart.HealPower);
            }
        }
    }
}
