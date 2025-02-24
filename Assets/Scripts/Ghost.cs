using UnityEngine;

public class Ghost : MonoBehaviour 
{
    [SerializeField] private Transform[] _waypoints;

    private Vector2 _direction;
    private SpriteRenderer _spriteRenderer;
    private float _speed = 4f;
    private int _correntWaypoint = 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        if (transform.position == _waypoints[_correntWaypoint].position)
        {
            _correntWaypoint = (_correntWaypoint + 1) % _waypoints.Length;
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_correntWaypoint].position, _speed * Time.deltaTime);
    }

    private void Flip()
    {
        _direction = _waypoints[_correntWaypoint].position - transform.position;

        if (_direction.x > 0)
        {
            _spriteRenderer.flipX = true; 
        }
        else if (_direction.x < 0)
        {
            _spriteRenderer.flipX = false; 
        }
    }
}