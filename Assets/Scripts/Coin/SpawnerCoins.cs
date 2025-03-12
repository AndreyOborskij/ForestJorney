using System.Collections;
using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private Coin _prefabCoin;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        Create();
    }

    private void Create()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Coin coin = Instantiate(_prefabCoin);

            coin.Disappeared += ResetCoin;

            coin.transform.position = _spawnPoints[i].position;
        }
    }

    private void ResetCoin(Coin coin)
    {
        coin.Disappeared -= ResetCoin;

        StartCoroutine(ReloadCoin(coin, coin.ResetTime));
    }

    private IEnumerator ReloadCoin(Coin coin, float resetTime)
    {
        var wait = new WaitForSecondsRealtime(resetTime);

        coin.gameObject.SetActive(false);

        yield return wait;

        coin.Disappeared += ResetCoin;
        coin.gameObject.SetActive(true);
    }
}
