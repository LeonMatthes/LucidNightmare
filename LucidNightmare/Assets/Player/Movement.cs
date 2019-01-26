using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 50;
    public Text countText;


    private CharacterController controller;
    private Vector3 moveDirection;
    private int count;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        count = 0;
        SetCountText();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveDirection = moveHorizontal * transform.right + moveVertical * transform.forward + Physics.gravity;
        if (moveDirection.magnitude > 1.0f)
        {
            moveDirection.Normalize();
        }

        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pellets"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = count.ToString()+ "/200";
        /*if (count >= 12)
        {
           Winning Condition here
        }*/
    }
}

