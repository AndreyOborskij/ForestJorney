using System;

public abstract class ItemBehaviour<T> : ItemObject where T : ItemBehaviour<T>
{
    public event Action<T> Collected;

    public override void Collect()
    {
        Collected?.Invoke((T)this);
    }
}
