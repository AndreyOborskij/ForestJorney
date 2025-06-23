using UnityEngine;

public class DieZone : MonoBehaviour
{
    [SerializeField] private Health _health;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out BaseballBat baseballBat))
        {
            _health.DecreaseValue(baseballBat.PowerHit);
        }
    }
}
