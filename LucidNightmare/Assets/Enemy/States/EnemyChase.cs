using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    protected float timeOut = 10;

    public EnemyChase(Enemy enemy)
        : base(enemy)
    {
        enemy.agent.SetDestination(enemy.targetTransform.position);
    }
    
    public override void Update()
    {
        timeOut -= Time.deltaTime;
        if(timeOut <= 0)
        {
            enemy.state = new EnemyReturnToStart(enemy);
        }
    }
}
