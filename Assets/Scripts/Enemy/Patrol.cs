using UnityEngine;

public class Patrol : MonoBehaviour
{
    private Transform _waypoint;
    private int _correntWaypoint = 0;
    private float _direction;

    public Transform ChackWaypoint(Transform[] waypoints)
    {
        if (transform.position == waypoints[_correntWaypoint].position)
        {
            _correntWaypoint = (++_correntWaypoint) % waypoints.Length;
        }

        _waypoint = waypoints[_correntWaypoint];

        return _waypoint;
    }

    public float ChackDirection()
    {
        _direction = transform.position.x - _waypoint.position.x;

        return _direction;
    }
}