using UnityEngine;

public class DieZone : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out BaseballBat baseballBat))
        {
            _enemy.gameObject.SetActive(false);
        }
    }
}
