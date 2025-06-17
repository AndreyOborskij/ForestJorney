using System;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    public event Action Comming;
    public event Action Left;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Comming?.Invoke();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Left?.Invoke();
        }
    }
}
