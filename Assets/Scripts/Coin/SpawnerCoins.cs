using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private Coin _prefabCoin;
    [SerializeField] private Transform[] _spawnPoints;

    private ObjectPool<Coin> _coinsPool;

    private void Awake()
    {
        _coinsPool = new ObjectPool<Coin>(
            createFunc: () => Instantiate(_prefabCoin)
            );
    }

    private void Start()
    {
        Create();
    }

    private void Create()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Coin coin = _coinsPool.Get();

            coin.Disappeared += ResetCoin;

            coin.transform.position = _spawnPoints[i].position;

            coin.gameObject.SetActive(true);
        }
    }

    private void ResetCoin(Coin coin)
    {
        StartCoroutine(ReloadCoin(coin, coin.ResetTime));
    }

    private IEnumerator ReloadCoin(Coin coin, float resetTime)
    {
        var wait = new WaitForSecondsRealtime(resetTime);

        coin.gameObject.SetActive(false);

        yield return wait;

        coin.gameObject.SetActive(true);
    }
}
