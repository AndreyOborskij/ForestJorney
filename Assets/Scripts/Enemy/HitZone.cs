using System;

public class HitZone : TriggerObserver
{
    public event Action Comming;
    public event Action Left;

    protected override void CamePlayer(Player player)
    {
        Comming?.Invoke();
    }

    protected override void LeftPlayer(Player player)
    {
        Left?.Invoke();
    }
}
