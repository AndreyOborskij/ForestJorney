using System;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Action<Heart> Collected;

    private int _healPower = 10;

    public int HealPower => _healPower;

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}
