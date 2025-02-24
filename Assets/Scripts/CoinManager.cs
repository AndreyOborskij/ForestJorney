using System.Collections;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public void ResetCoin(Coin coin, float resetTime)
    {
        StartCoroutine(ReloadCoin(coin, resetTime));
    }

    private IEnumerator ReloadCoin(Coin coin, float resetTime)
    {
        var wait = new WaitForSecondsRealtime(resetTime);

        coin.gameObject.SetActive(false);

        yield return wait;

        coin.gameObject.SetActive(true);
    }    
}