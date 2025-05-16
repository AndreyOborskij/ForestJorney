using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public event Action<Item> Collected;

    public abstract void Collect();

    protected void NotifyCollected()
    {
        Collected?.Invoke(this); 
    }
}
