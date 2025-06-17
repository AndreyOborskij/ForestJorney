using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAI _enemyAI;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Transform[] _waypoints;

    private void Update()
    {
        _enemyAI.ChooseWaypoint(_waypoints);
        _flipper.Flip(_enemyAI.DetermineDirection());
    }
}
