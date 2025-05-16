using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    private int _countGroundCollisions = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _countGroundCollisions++;
        IsGrounded = _countGroundCollisions > 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _countGroundCollisions--;
        IsGrounded = _countGroundCollisions > 0;
    }
}
