using System;
using UnityEngine;

public class ContactTracker : MonoBehaviour
{
    public event Action<Player> Came;
    public event Action Left;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Came?.Invoke(player);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Left?.Invoke();
            player.RunAway();
        }
    }
}
