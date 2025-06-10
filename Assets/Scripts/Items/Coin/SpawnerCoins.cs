using UnityEngine;

public class SpawnerCoins : SpawnerItems<Coin>
{
    [SerializeField] private Coin _prefabCoin;
    [SerializeField] private Transform[] _spawnPoints;

    protected override void SpawnItems()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            var coin = Instantiate(_prefabCoin);

            coin.transform.position = _spawnPoints[i].transform.position;

            RegisterItem(coin);
        }
    }
}

