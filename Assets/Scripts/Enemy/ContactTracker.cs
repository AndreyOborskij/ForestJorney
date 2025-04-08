using System;
using UnityEngine;

public class ContactTracker : MonoBehaviour
{
    public Action<Player> Came;
    public Action Left;

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
