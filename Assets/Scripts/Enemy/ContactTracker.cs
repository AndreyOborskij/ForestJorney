using System;

public class ContactTracker : TriggerObserver
{
    public event Action<Player> Came; //COME неправильный глагол прошедшее время CAME
    public event Action Left; //LEAVE неправильный глагол прошедшее время LEFT

    protected override void PlayerCame(Player player)
    {
        Came?.Invoke(player);
    }

    protected override void PlayerLeft(Player player)
    {
        Left?.Invoke();
    }
}
