using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public new Camera camera;
    public NavMeshAgent agent;
    public Transform targetTransform;

    public Transform[] path;

    [HideInInspector]
    public Vector3 basePosition;

    [HideInInspector]
    public EnemyState state;


    // Start is called before the first frame update
    void Start()
    {
        basePosition = transform.position;
        returnToIdle();
    }


    // Update is called once per frame
    void Update()
    {
        state.Update();
    }

    public void returnToIdle()
    {
        if(path.Length == 0)
        {
            state = new EnemyIdle(this);
        }
        else
        {
            state = new EnemyFollowPath(this);
        }
    }

}
