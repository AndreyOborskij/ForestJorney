using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patrol _patrol;
    [SerializeField] private MoverEnemy _moverEnemy;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Transform[] _waypoints;

    private void Update()
    {
        _moverEnemy.Move(_patrol.ChackWaypoint(_waypoints));
        _flipper.Flip(_patrol.ChackDirection());
    }
}
