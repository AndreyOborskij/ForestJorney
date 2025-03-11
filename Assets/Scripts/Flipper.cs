using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Quaternion _rotateRight;
    private Quaternion _rotateLeft;

    public void Awake()
    {
        _rotateRight = Quaternion.Euler(0, 0, 0);
        _rotateLeft = Quaternion.Euler(0, 180, 0);
    }

    public void Flip(float direction)
    {
        if (direction > 0)
        {
            transform.rotation = _rotateRight;
        }
        else if (direction < 0)
        {
            transform.rotation = _rotateLeft;
        }
    }
}
