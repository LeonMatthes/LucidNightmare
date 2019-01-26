using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    public EnemyChase(Enemy enemy)
        : base(enemy)
    {
    }
    
    public override void Update()
    {
        if(Vector3.Distance(enemy.targetTransform.position, enemy.transform.position) > enemy.distanceToChase)
        {
            enemy.returnToIdle();
        }
        else
        {
            enemy.agent.SetDestination(enemy.targetTransform.position);
        }
    }
}
