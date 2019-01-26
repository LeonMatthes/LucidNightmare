using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed  = 50;

    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveDirection = moveHorizontal * transform.right + moveVertical * transform.forward;
        if (moveDirection.magnitude > 1.0f)
        {
            moveDirection.Normalize();
        }

        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        
    }

    void Move()
    {
        //rb.MovePosition(rb.position + (moveDirection * speed * Time.deltaTime));
        //rb.AddForce(moveDirection * speed);
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pellets"))
        {
            other.gameObject.SetActive(false);
        }
    }
}

