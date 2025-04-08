using UnityEngine;

public class Follower : MonoBehaviour
{
    private float _speed = 3;

    public void Move(Player player)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
    }
}
