using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedSpawn : MonoBehaviour
{
    public float delay = 10;
    public Transform spawnPoint;
    public GameObject objectToSpawn;
    public Transform targetOfEnemy;

    private bool countdown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown && delay > 0)
        {
            delay -= Time.deltaTime;
            if(delay <= 0)
            {
                spawnObject();
            }
        }
    }

    void spawnObject()
    {
        Enemy enemy = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation).GetComponent<Enemy>();
        enemy.distanceToChase = int.MaxValue;
        enemy.targetTransform = targetOfEnemy;
        DestroyImmediate(this.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Movement>() != null)
        {
            countdown = true;
        }
    }
}
