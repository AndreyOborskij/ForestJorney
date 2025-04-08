using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private AttackChecker _attackChecker;
    [SerializeField] private MoverPlayer _moverCollector;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Ñollector _collector;  
    [SerializeField] private Wallet _wellet;
    [SerializeField] private Healthbar _healthbar;

    private void OnEnable()
    {
        _collector.Took += PutOnWellet;
        _collector.Healed += TakeHealth;
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
    }

    private void PutOnWellet()
    {
        _wellet.IncreaseItem();
    }

    public void TakeDamage(int damage)
    {
        _healthbar.DecreaseValue(damage);
        _attackChecker.TakeHit();
    }

    public void TakeHealth(int heal)
    {
        _healthbar.IncreaseValue(heal);
    }    

    public void RunAway()
    {
        _attackChecker.AvoidHit();
    }
}