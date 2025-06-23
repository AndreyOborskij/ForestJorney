using UnityEngine;

public abstract class Behaviour : MonoBehaviour
{
    [SerializeField] protected Transform[] _waypoints; 
    [SerializeField] protected MoverEnemy _moverEnemy;

    protected Player _player;
    private Vector2 _waypoint;
    private float _direction;
    private int _correntWaypoint = 0;
    
    public virtual void Walk()
    {
        _moverEnemy.Move(ChooseWaypoint());
    }

    public virtual float DetermineDirection()
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

    protected virtual Vector2 ChooseWaypoint()
    {
        if (transform.position == _waypoints[_correntWaypoint].position)
        {
            _correntWaypoint = ++_correntWaypoint % _waypoints.Length;
        }

        _waypoint = _waypoints[_correntWaypoint].position;

        return _waypoint;
    }
}