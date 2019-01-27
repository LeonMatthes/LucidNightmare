using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 50;
    public Text countText;
    public AudioClip TenCollectibles;
    public AudioClip TwentyCollectibles;
    public AudioClip ThirtyCollectibles;
    public AudioClip CreepySound;
    AudioSource audioSource;
    public AudioClip[] Pellet;
    private AudioClip pelletClip;
    public AudioClip[] Moving;
    private AudioClip movingClip;


    private CharacterController controller;
    private Vector3 moveDirection;
    public int count;
    public int PelletsCount;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        count = 0;
        PelletsCount = GameObject.FindGameObjectsWithTag("Pellets").Length;
        SetCountText();
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("PlayCreepSound", 2.0f, 45.3f);
        
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveDirection = moveHorizontal * transform.right + moveVertical * transform.forward + Physics.gravity;
        if (moveDirection.magnitude > 1.0f)
        {
            moveDirection.Normalize();
            /*int index = Random.Range(0, Moving.Length);
            movingClip = Moving[index];
            audioSource.clip = movingClip;
            audioSource.Play();
            Move Sounds*/
        }

        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pellets"))
        {
            other.gameObject.SetActive(false);
            int index = Random.Range(0, Pellet.Length);
            pelletClip = Pellet[index];
            audioSource.clip = pelletClip;
            audioSource.Play();
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = count.ToString()+ "/" + PelletsCount;
        if (count == 10)
        {
            audioSource.PlayOneShot(TenCollectibles);
        }
        if (count == 20)
        {
            audioSource.PlayOneShot(TwentyCollectibles);
        }
        if (count == 30)
        {
            audioSource.PlayOneShot(ThirtyCollectibles);
        }
        if (count == 30)
        {
            audioSource.PlayOneShot(TenCollectibles);
        }
    }
    void PlayCreepSound()
    {
        audioSource.PlayOneShot(CreepySound);
    }
}

