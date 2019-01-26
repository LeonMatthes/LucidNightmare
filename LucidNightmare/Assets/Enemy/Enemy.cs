using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        state = new EnemyIdle(this);
        basePosition = transform.position;
    }

    public new Camera camera;
    public NavMeshAgent agent;
    public Transform targetTransform;

    [HideInInspector]
    public Vector3 basePosition;

    [HideInInspector]
    public EnemyState state;

    // Update is called once per frame
    void Update()
    {
        state.Update();
    }
}
