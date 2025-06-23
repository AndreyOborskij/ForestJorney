using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ContactTracker _contactTracker;
    [SerializeField] private MoverEnemy _moverEnemy;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private PatrolBehaviour _patrolBehaviour;
    [SerializeField] private ChaseBehaviour _chaseBehaviour;
    [SerializeField] private Health _health;

    private Behaviour _behaviour;
    private Player _player;

    private void OnEnable()
    {
        _contactTracker.Came += SeePlayer;
        _contactTracker.Left += LoosePlayer;
        _health.Died += Die;
    }

    private void Start()
    {
        _behaviour = _patrolBehaviour;
    }

    private void Update()
    {
        _behaviour.Walk();
        _flipper.Flip(_behaviour.DetermineDirection());
    }

    private void OnDisable()
    {
        _contactTracker.Came -= SeePlayer;
        _contactTracker.Left -= LoosePlayer;
        _health.Died -= Die;
    }

    private void SeePlayer(Player player)
    {
        _player = player;

        _chaseBehaviour.SetTrigger(_player);

        _behaviour = _chaseBehaviour;
    }

    private void LoosePlayer()
    {
        _player = null;
        _behaviour = _patrolBehaviour;
    }   
    
    private void Die()
    {
        gameObject.SetActive(false);
    }
}
