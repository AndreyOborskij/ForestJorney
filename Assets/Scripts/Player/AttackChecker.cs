using UnityEngine;

public class AttackChecker : MonoBehaviour
{
    public bool IsAttacked { get; private set; }

    public void TakeHit()
    {
        IsAttacked = true;
    }

    public void AvoidHit()
    {
        IsAttacked = false;
    }
}
