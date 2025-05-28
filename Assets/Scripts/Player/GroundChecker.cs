using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private int _countGroundCollisions = 0;

    public bool IsGrounded => _countGroundCollisions > 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _countGroundCollisions++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _countGroundCollisions--;
    }
}
