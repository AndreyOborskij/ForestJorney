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

    protected abstract void PlayerCame(Player player); //COME ������������ ������ ��������� ����� CAME
    protected abstract void PlayerLeft(Player player); //LEAVE ������������ ������ ��������� ����� LEFT
}