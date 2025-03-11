using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Action<Coin> Disappeared;

    public float ResetTime => 4f;

    public void Disappear()
    {
        Disappeared?.Invoke(this);
    }
}