using UnityEngine;

public class FlipperEnemy : MonoBehaviour 
{
    [SerializeField] private Transform[] _waypoints;

    private Vector2 _direction;
    private int _correntWaypoint = 0;

    private void Update()
    {
        Flip();
    }

    private void Flip()
    {
        if (transform.position == _waypoints[_correntWaypoint].position)
        {
            _correntWaypoint = (_correntWaypoint + 1) % _waypoints.Length;
        }

        _direction = transform.position - _waypoints[_correntWaypoint].position;
        transform.right = _direction;
    }
}