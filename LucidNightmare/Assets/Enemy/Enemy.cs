using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetTransform;

    public Transform pathParent;

    public float distanceToChase = 10;

    [HideInInspector]
    public EnemyState state;

    [HideInInspector]
    public List<Transform> path = new List<Transform>();

    public Enemy()
        :base()
    {
        returnToIdle();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(pathParent != null)
        {
            foreach (Transform transform in pathParent)
            {
                path.Add(transform);
            }
        }

        returnToIdle();
    }


    // Update is called once per frame
    void Update()
    {
        state.Update();
    }

    public void returnToIdle()
    {
        if(path.Count == 0)
        {
            state = new EnemyIdle(this);
        }
        else
        {
            state = new EnemyFollowPath(this);
        }
    }

}
