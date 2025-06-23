using System;

public class HitZone : TriggerObserver
{
    public event Action Comming;
    public event Action Left; //LEAVE ������������ ������ ��������� ����� LEFT

    protected override void PlayerCame(Player player)
    {
        Comming?.Invoke();
    }

    protected override void PlayerLeft(Player player)
    {
        Left?.Invoke();
    }
}
