using System.Collections;
using UnityEngine;

public class SpawnerHearts : SpawnerItems<Heart>
{
    [SerializeField] private Heart _prefabHeart;
    [SerializeField] private Transform[] _spawnPositions;

    protected override void SpawnItems()
    {
        var heart = Instantiate(_prefabHeart);

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
        int index = Random.Range(0, _spawnPositions.Length);
        return _spawnPositions[index].position;
    }
}
