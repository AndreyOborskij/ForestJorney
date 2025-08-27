using System.Collections.Generic;
using UnityEngine;

public class DistanceMeasurer : MonoBehaviour
{
    private Enemy _targetEnemy;

    public Enemy DetermineNearestEnemy(List<Enemy> enemies)
    {
        if(enemies.Count == 0)
            return null;

        _targetEnemy = enemies[0];
        float shortestDistance = Calculate(_targetEnemy);

        for (int i = 1; i < enemies.Count; i++)
        {
            float currentDistent = Calculate(enemies[i]);

            if (shortestDistance > currentDistent)
            {
                shortestDistance = currentDistent;
                _targetEnemy = enemies[i];
            }
        }

        return _targetEnemy;
    }

    private float Calculate(Enemy enemy)
    {
        return Vector2.Distance(transform.position, enemy.transform.position);
    }
}
