using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private Transform _flippingObject;

    public void Flip(float direction)
    {
        if (direction > 0)
        {
            _flippingObject.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction < 0)
        {
            _flippingObject.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
