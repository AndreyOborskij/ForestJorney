using UnityEngine;

public class FlipperPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void Flip(float _direction)
    {
        if (_direction > 0)
        {
            _player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_direction < 0)
        {
            _player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
