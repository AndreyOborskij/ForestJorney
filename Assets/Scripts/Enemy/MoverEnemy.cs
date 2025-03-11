using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    private float _speed = 4f;
   
    public void Move(Transform waypoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint.position, _speed * Time.deltaTime);
    }
}