using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private ContactTracker _contactTracker;
    [SerializeField] private MoverEnemy _moverEnemy;

    private Transform _waypoint;
    private Player _purpose;
    private int _correntWaypoint = 0;
    private float _direction;
    private bool _isCome;

    private void OnEnable()
    {
        _contactTracker.Came += DefinePlayer;
        _contactTracker.Left += StopFollow;
    }

    private void OnDisable()
    {
        _contactTracker.Came -= DefinePlayer;
        _contactTracker.Left -= StopFollow;
    }

    public void MoveAround(Transform[] waypoints)
    {
        if (_isCome == true)
        {
            _moverEnemy.Move(_purpose.transform.position);
        }
        else
        {
            _moverEnemy.Move(ChackWaypoint(waypoints));
        }
    }

    public float DetermineDirection()
    {
        if (_isCome == true)
        {
            _direction = transform.position.x - _purpose.transform.position.x;
        }
        else
        {
            _direction = transform.position.x - _waypoint.position.x;
        }

        return _direction;
    }

    private Vector2 ChackWaypoint(Transform[] waypoints)
    {
        if (transform.position == waypoints[_correntWaypoint].position)
        {
            _correntWaypoint = ++_correntWaypoint % waypoints.Length;
        }

        _waypoint = waypoints[_correntWaypoint];

        return _waypoint.transform.position;
    }    

    private void DefinePlayer(Player player)
    {
        _purpose = player;
        _isCome = true;
    }

    private void StopFollow()
    {
        _purpose = null;
        _isCome = false;
    }
}