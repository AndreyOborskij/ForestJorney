using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private AttackChecker _attackChecker;
    [SerializeField] private Mover _moverCollector;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Collector _collector;
    [SerializeField] private Wallet _wellet;
    [SerializeField] private Health _health;
    [SerializeField] private ChangerPlayerAnimations _changerPlayerAnimations;
    [SerializeField] private Hit[] _hit;

    private void OnEnable()
    {
        _collector.Took += PutOnWellet;
        _collector.Healed += TakeHealth;

        foreach (var hit in _hit)
            hit.DealtDamage += TakeDamage;
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        _moverCollector.Move(_inputReader.Direction);
        _flipper.Flip(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundChecker.IsGrounded)
            _moverCollector.Jump();
    }

    private void OnDisable()
    {
        _collector.Took -= PutOnWellet;
        _collector.Healed -= TakeHealth;

        foreach (var hit in _hit)
            hit.DealtDamage -= TakeDamage;
    }

    private void TakeHealth(int heal)
    {
        _health.IncreaseValue(heal);
    }

    private void TakeDamage(int damage)
    {
        _health.DecreaseValue(damage);
    }

    private void PutOnWellet()
    {
        _wellet.IncreaseItem();
    }

    private void Move()
    {
        _changerPlayerAnimations.UpdateMovement(_inputReader.Direction);
        _changerPlayerAnimations.UpdateJump(_groundChecker.IsGrounded);
        _changerPlayerAnimations.UpdateDealDamage(_attackChecker.IsAttacked);
    }
}