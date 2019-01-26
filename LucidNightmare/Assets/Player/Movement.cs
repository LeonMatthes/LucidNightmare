using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed  = 200;

    private Rigidbody rb;
    Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //rb.AddForce(movement * speed * Time.deltaTime);

       /* Vector3 moveDirection = (moveHorizontal * transform.right + moveVertical * transform.forward);
        if (moveDirection.magnitude > 1)
        {
            moveDirection = moveDirection.normalized;
        }*/
        moveDirection = (moveHorizontal * transform.right + moveVertical * transform.forward).normalized;
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.MovePosition(rb.position + (moveDirection * speed * Time.deltaTime));
    }
}

