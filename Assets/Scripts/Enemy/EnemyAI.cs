using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private ContactTracker _contactTracker;
    [SerializeField] private MoverEnemy _moverEnemy;

    private enum State { Patrol, Chase }
    private State _currentState;
    private Vector2 _waypoint;
    private Player _player;
    private float _direction;
    private int _correntWaypoint = 0;


    private void OnEnable()
    {
        _contactTracker.Left += PlayerLeft;
        _contactTracker.Came += PlayerSeen;
    }

    private void Start()
    {
        _currentState = State.Patrol;
    }

    private void OnDisable()
    {
        _contactTracker.Left -= PlayerLeft;
        _contactTracker.Came -= PlayerSeen;
    }

    private void Update()
    {
        ChooseBehaviour();
    }

    public Vector2 ChooseWaypoint(Transform[] waypoints)
    {
        if (transform.position == waypoints[_correntWaypoint].position)
        {
            _correntWaypoint = ++_correntWaypoint % waypoints.Length;
        }

        _waypoint = waypoints[_correntWaypoint].position;

        return _waypoint;
    }

    public float DetermineDirection()
    {
        if (_player != null)
        {
            _direction = transform.position.x - _player.transform.position.x;
        }
        else
        {
            _direction = transform.position.x - _waypoint.x;
        }

        return _direction;
    }

    private void ChooseBehaviour()
    {
        switch (_currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Chase:
                Chase();
                break;
        }
    }

    private void Patrol()
    {
        _moverEnemy.Move(_waypoint);
    }

    private void Chase()
    {
        _moverEnemy.Move(_player.transform.position);
    }

    private void PlayerSeen(Player player)
    {
        _player = player;
        _currentState = State.Chase;
    }

    private void PlayerLeft()
    {
        _player = null;
        _currentState = State.Patrol;
    }
}
