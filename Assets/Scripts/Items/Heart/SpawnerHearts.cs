using System.Collections;
using UnityEngine;

public class SpawnerHearts : MonoBehaviour
{
    [SerializeField] private Heart _prefabHeart;
    [SerializeField] private Transform[] _spawnPositions;

    private Heart _heart;
    private int _spawnPoint;
    private float _resetTime = 2f;

    private void Awake()
    {
        _heart = Instantiate(_prefabHeart);
    }

    private void OnEnable()
    {
        _heart.Collected += Spawn;
    }

    private void Start()
    {
        DeterminePosition();
    }

    private void OnDisable()
    {
        _heart.Collected -= Spawn;
    }

    private void DeterminePosition()
    {
        _spawnPoint = Random.Range(0, _spawnPositions.Length);

        _heart.transform.position = _spawnPositions[_spawnPoint].position;
    }

    private void Spawn(Item item)
    {
        if (item is Heart heart)
        {
            StartCoroutine(Respawn(heart));
        }
    }

    private IEnumerator Respawn(Heart heart)
    {
        var wait = new WaitForSeconds(_resetTime);

        heart.gameObject.SetActive(false);

        yield return wait;

        DeterminePosition();
        heart.gameObject.SetActive(true);
    }
}
