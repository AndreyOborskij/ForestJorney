using System.Collections;
using UnityEngine;

public abstract class SpawnerItems<T> : MonoBehaviour where T : ItemLogic<T>
{
    protected virtual void Start()
    {
        SpawnItems();
    }

    protected abstract void SpawnItems();

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
        item.gameObject.SetActive(false);
        yield return new WaitForSeconds(item.ResetTime);
        item.gameObject.SetActive(true);
    }
}