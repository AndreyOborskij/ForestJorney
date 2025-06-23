using System.Collections;
using UnityEngine;

public abstract class SpawnerItems<T> : MonoBehaviour where T : ItemBehaviour<T>
{
    [SerializeField] protected T _itemPrefab;
    [SerializeField] protected Transform[] _spawnPoints;

    protected virtual void Start()
    {
        SpawnItems();
    }

    protected virtual void SpawnItems()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            T item = Instantiate(_itemPrefab);
            item.transform.position = _spawnPoints[i].transform.position; 
            RegisterItem(item);
        }
    }

    protected void RegisterItem(T item)
    {
        item.Collected += ItemCollected;
    }

    protected void ItemCollected(T item)
    {
        StartCoroutine(Respawn(item));
    }

    protected virtual IEnumerator Respawn(T item)
    {
        item.Collected -= ItemCollected;

        item.gameObject.SetActive(false);

        yield return new WaitForSeconds(item.ResetTime);

        item.gameObject.SetActive(true);
    }
}