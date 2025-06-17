using System.Collections;
using UnityEngine;

public class SpawnerHearts : SpawnerItems<Heart>
{
    protected override void SpawnItems()
    {
        var heart = Instantiate(_itemPrefab);

        heart.transform.position = GetSpawnPosition();

        RegisterItem(heart);
    }

    protected override IEnumerator Respawn(Heart item)
    {
        item.transform.position = GetSpawnPosition();
        return base.Respawn(item);
    }

    private Vector2 GetSpawnPosition()
    {
        int index = Random.Range(0, _spawnPoints.Length);
        return _spawnPoints[index].position;
    }
}
