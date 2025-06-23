using System;

public class ContactTracker : TriggerObserver
{
    public event Action<Player> Came; 
    public event Action Left; 

    protected override void CamePlayer(Player player)
    {
        Came?.Invoke(player);
    }

    protected override void LeftPlayer(Player player)
    {
        Left?.Invoke();
    }
}
