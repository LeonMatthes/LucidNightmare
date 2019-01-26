using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    public EnemyIdle(Enemy enemy)
        : base(enemy)
    {

    }

    // Update is called once per frame
    public override void Update()
    {
        if(Vector2.Distance(enemy.transform.position, enemy.targetTransform.position) < 10)
        {
            enemy.state = new EnemyChase(enemy);
        }
    }
}
