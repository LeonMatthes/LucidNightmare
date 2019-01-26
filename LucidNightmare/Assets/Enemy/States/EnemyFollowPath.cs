using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPath : EnemyState
{
    protected int index = 0;
    protected float distanceThreshold = 2;

    public EnemyFollowPath(Enemy enemy)
        :base(enemy)
    {
        if(enemy.path.Length == 0)
        {
            enemy.state = new EnemyIdle(enemy);
        }
        else
        {
            enemy.agent.SetDestination(nextPosition());
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        if(Vector3.Distance(enemy.transform.position, nextPosition()) <= distanceThreshold)
        {
            index++;
            index %= enemy.path.Length;
        }

        enemy.agent.SetDestination(nextPosition());

        if (Vector2.Distance(enemy.transform.position, enemy.targetTransform.position) < enemy.distanceToChase)
        {
            enemy.state = new EnemyChase(enemy);
        }
    }

    private Vector3 nextPosition()
    {
        if(index > enemy.path.Length)
        {
            index %= enemy.path.Length;
        }

        if(index < 0)
        {
            index = 0;
        }
        return enemy.path[index].position;
    }
}
