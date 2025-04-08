using UnityEngine;

public class HitZone : MonoBehaviour
{
    private int _damage = 10;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }
}
