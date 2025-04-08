using System;
using UnityEngine;

public class �ollector : MonoBehaviour
{
    public Action Took;
    public Action<int> Healed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Disappear();
            Took?.Invoke();
        }

        if(other.gameObject.TryGetComponent(out Heart heart))
        {
            heart.Collect();
            Healed?.Invoke(heart.HealPower);
        }
    }
}
