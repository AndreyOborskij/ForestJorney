using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    private float _speed = 4f;

    public void Move(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}