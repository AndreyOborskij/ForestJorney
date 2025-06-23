using UnityEngine;

public abstract class TriggerObserver : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerCame(player);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerLeft(player);
        }
    }

    protected abstract void PlayerCame(Player player); //COME неправильный глагол прошедшее время CAME
    protected abstract void PlayerLeft(Player player); //LEAVE неправильный глагол прошедшее время LEFT
}