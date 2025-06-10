using System;

public abstract class ItemLogic<T> : ItemObject where T : ItemLogic<T>
{
    public event Action<T> Collected;

    protected void NotifyCollected()
    {
        Collected?.Invoke((T)this);
    }
}
