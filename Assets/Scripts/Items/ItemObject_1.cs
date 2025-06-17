using System;

public abstract class ItemObject<T> : ItemObject where T : ItemObject<T>
{
    public event Action<T> Collected;

    public override void Collect()
    {
        Collected?.Invoke((T)this);
    }
}
