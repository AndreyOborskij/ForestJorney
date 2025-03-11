using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private MoverCollector _moverCollector;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Wallet _wellet;

    private void FixedUpdate()
    {
        _moverCollector.Move(_inputReader.Direction);
        _flipper.Flip(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundChecker.IsGrounded)
            _moverCollector.Jump();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            _wellet.IncreaseValue();
            coin.Disappear();
        }
    }
}
