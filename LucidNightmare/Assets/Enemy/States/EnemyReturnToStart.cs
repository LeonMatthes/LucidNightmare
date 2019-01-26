using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReturnToStart : EnemyState
{
    public EnemyReturnToStart(Enemy enemy)
        : base(enemy)
    {
        enemy.agent.SetDestination(enemy.basePosition);
    }

    public override void Update()
    {
        float distanceThreshold = 3;
        if (Vector3.Distance(enemy.transform.position, enemy.basePosition) <= distanceThreshold)
        {
            enemy.returnToIdle();
        }
    }
}
