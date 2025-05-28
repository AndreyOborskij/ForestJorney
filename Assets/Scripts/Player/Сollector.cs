using System;
using UnityEngine;

public class Ñollector : MonoBehaviour
{
    public event Action Took;
    public event Action<int> Healed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Collect();
            Took?.Invoke();
        }

        if(other.gameObject.TryGetComponent(out Heart heart))
        {
            heart.Collect();
            Healed?.Invoke(heart.HealPower);
        }
    }
}
