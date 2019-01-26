using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    public float degreesPerSecond = 90;
    public float degreesToOpen = -90;

    public float timeToOpen = 3;

    protected NavMeshObstacle obstacle;
    protected MeshRenderer meshRenderer;
    protected Rigidbody rigidBody;
    protected float openingTimer;
    protected bool timerEnabled;

    protected Quaternion openRotation;
    protected Quaternion closedRotation;
    protected Quaternion targetRotation;

    protected HashSet<Collider> overlaps = new HashSet<Collider>();
    

    // Start is called before the first frame update
    void Start()
    {
        obstacle = GetComponent<NavMeshObstacle>();
        meshRenderer = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();

        openingTimer = timeToOpen;
        timerEnabled = false;

        targetRotation = closedRotation = transform.rotation;
        openRotation = transform.rotation * Quaternion.Euler(Vector3.up * degreesToOpen);
    }

    private void rotateToAroundPoint(Rigidbody rigidBody, Quaternion currentRotation, Quaternion targetRotation, Vector3 originPoint, float degreesPerSecond)
    {
        Quaternion newRotation = Quaternion.RotateTowards(currentRotation, targetRotation, Time.deltaTime * degreesPerSecond);
        rigidBody.MoveRotation(newRotation);
        Quaternion deltaRotation = newRotation * Quaternion.Inverse(currentRotation);
        rigidBody.MovePosition(deltaRotation * (rigidBody.position - originPoint) + originPoint);
    }

    // Update is called once per frame
    void Update()
    {
        rotateToAroundPoint(rigidBody, rigidBody.rotation, targetRotation, transform.parent.position, degreesPerSecond);

        if (timerEnabled)
        {
            openingTimer -= Time.deltaTime;
            if(openingTimer <= 0)
            {
                open();
            }
        }

        if(Input.GetButtonDown("Interact"))
        {
            foreach(Collider overlap in overlaps)
            {
                Movement movement = overlap.GetComponent<Movement>();
                if(movement != null)
                {
                    switchState();
                }
            }
        }
    }

    public void switchState()
    {
        if(isOpen())
        {
            close();
        }
        else
        {
            open();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        overlaps.Add(other);

        if (other.GetComponent<Enemy>() != null)
        {
            startTimer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        overlaps.Remove(other);
        bool foundEnemyOrPlayer = false;
        foreach(Collider overlap in overlaps)
        {
            if(overlap.GetComponent<Enemy>() != null || overlap.GetComponent<Movement>() != null)
            {
                foundEnemyOrPlayer = true;
            }
        }
        if(!foundEnemyOrPlayer)
        {
            close();
        }
    }

    public bool isOpen()
    {
        return targetRotation == openRotation;
    }

    public void open()
    {
        stopTimer();
        targetRotation = openRotation;
    }

    public void close()
    {
        stopTimer();
        targetRotation = closedRotation;
    }

    private void startTimer()
    {
        if(!timerEnabled)
        {
            openingTimer = timeToOpen;
        }
        timerEnabled = true;
    }

    private void stopTimer()
    {
        openingTimer = timeToOpen;
        timerEnabled = false;
    }
}
