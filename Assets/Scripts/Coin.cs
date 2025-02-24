using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;

    private float _resetTime = 4f;

    public void Disappear()
    {
        _coinManager.ResetCoin(this, _resetTime);
    }
}