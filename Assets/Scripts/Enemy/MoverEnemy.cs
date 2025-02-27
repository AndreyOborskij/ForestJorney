using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private float _speed = 4f;
    private int _correntWaypoint = 0;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position == _waypoints[_correntWaypoint].position)
        {
            _correntWaypoint = (_correntWaypoint + 1) % _waypoints.Length;
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_correntWaypoint].position, _speed * Time.deltaTime);
    }
}