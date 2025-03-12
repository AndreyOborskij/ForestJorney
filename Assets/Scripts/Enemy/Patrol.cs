using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private MoverEnemy _moverEnemy;

    private Transform _waypoint;
    private int _correntWaypoint = 0;
    private float _direction;

    public void MoveAround(Transform[] waypoints)
    {
        _moverEnemy.Move(ChackWaypoint(waypoints));
    }

    public float DetermineDirection()
    {
        _direction = transform.position.x - _waypoint.position.x;

        return _direction;
    }

    private Transform ChackWaypoint(Transform[] waypoints)
    {
        if (transform.position == waypoints[_correntWaypoint].position)
        {
            _correntWaypoint = ++_correntWaypoint % waypoints.Length;
        }

        _waypoint = waypoints[_correntWaypoint];

        return _waypoint;
    }
}