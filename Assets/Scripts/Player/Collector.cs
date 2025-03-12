using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public Action Took;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Disappear();
            Took?.Invoke();
        }
    }
}
