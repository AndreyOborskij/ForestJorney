using UnityEngine;

public abstract class TriggerObserver : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            CamePlayer(player);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            LeftPlayer(player);
        }
    }

    protected abstract void CamePlayer(Player player); 
    protected abstract void LeftPlayer(Player player); 
}