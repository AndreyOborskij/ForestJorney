using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinActivities _coinActivities;

    private float _resetTime = 4f;

    public void Disappear()
    {
        _coinActivities.ResetCoin(this, _resetTime);
    }
}