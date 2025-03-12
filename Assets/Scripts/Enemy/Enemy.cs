using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patrol _patrol;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Transform[] _waypoints;

    private void Update()
    {
        _patrol.MoveAround(_waypoints);
        _flipper.Flip(_patrol.DetermineDirection());
    }
}
