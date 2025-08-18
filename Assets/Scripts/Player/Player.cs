using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Mover _moverCollector;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Collector _collector;
    [SerializeField] private Wallet _wellet;
    [SerializeField] private Health _health;
    [SerializeField] private ChangerPlayerAnimations _changerPlayerAnimations;
    [SerializeField] private Weapon[] _weapon;

    private void OnEnable()
    {
        _collector.Took += PutOnWellet;
        _collector.Healed += TakeHealth;

        foreach (var weapon in _weapon)
        {
            weapon.AttackedDamage += TakeDamage;
            weapon.StoppedDamage += EndHitReaction;
        }

        _health.Damaged += StartHitReaction;
    }

    private void Update()
    {
        UpdateAnimationStates();
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

        foreach (var hit in _weapon)
        {
            hit.AttackedDamage -= TakeDamage;
            hit.StoppedDamage -= EndHitReaction;
        }

        _health.Damaged -= StartHitReaction;
    }

    private void TakeHealth(float heal)
    {
        _health.IncreaseValue(heal);
    }

    private void TakeDamage(float damage)
    {
        _health.DecreaseValue(damage);
    }

    private void PutOnWellet()
    {
        _wellet.IncreaseItem();
    }

    private void StartHitReaction()
    {
        _changerPlayerAnimations.UpdateDealDamage(true);
    }

    private void EndHitReaction()
    {
        _changerPlayerAnimations.UpdateDealDamage(false);
    }

    private void UpdateAnimationStates()
    {
        _changerPlayerAnimations.UpdateMovement(_inputReader.Direction);
        _changerPlayerAnimations.UpdateJump(_groundChecker.IsGrounded);
    }
}