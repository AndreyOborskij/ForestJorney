using UnityEngine;

public class AttackChecker : MonoBehaviour
{
    [SerializeField] private ContactTracker[] _contactTracker;
    [SerializeField] private HitZone[] _hitZone;

    private void OnEnable()
    {
        foreach (var contact in _contactTracker)
            contact.Left += AvoidHit;

        foreach (var hitZone in _hitZone)
            hitZone.Comming += TakeHit;
    }

    private void OnDisable()
    {
        foreach (var contact in _contactTracker)
            contact.Left += AvoidHit;

        foreach (var hitZone in _hitZone)
            hitZone.Comming += TakeHit;
    }

    public bool IsAttacked { get; private set; }

    private void TakeHit()
    {
        IsAttacked = true;
    }

    private void AvoidHit()
    {
        IsAttacked = false;
    }
}
