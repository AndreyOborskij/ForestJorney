using System;

public class ContactTracker : TriggerObserver
{
    public event Action<Player> Came; //COME ������������ ������ ��������� ����� CAME
    public event Action Left; //LEAVE ������������ ������ ��������� ����� LEFT

    protected override void PlayerCame(Player player)
    {
        Came?.Invoke(player);
    }

    protected override void PlayerLeft(Player player)
    {
        Left?.Invoke();
    }
}
