using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Wallet _wellet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            TakeCoin();
            coin.Disappear();
        }
    }

    public void TakeCoin()
    {
        _wellet.IncreaseValue();
    }
}
