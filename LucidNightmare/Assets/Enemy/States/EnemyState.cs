using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : Object
{
    protected Enemy enemy;

    public EnemyState(Enemy enemy)
    {
        this.enemy = enemy;
    }



    // Update is called once per frame
    public abstract void Update();
}
