using UnityEngine;

public abstract class ItemObject : MonoBehaviour
{
    public float ResetTime => 4f;

    public abstract void Collect();
}
