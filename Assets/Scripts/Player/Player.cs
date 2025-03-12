using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private MoverPlayer _moverCollector;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Collector _collector;
    [SerializeField] private Wallet _wellet;
 
    private void OnEnable()
    {
        _collector.Took += PutOnWellet;
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
    }

    private void PutOnWellet()
    {
        _wellet.IncreaseValue();
    }
}