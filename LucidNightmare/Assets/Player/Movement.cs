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
    public AudioClip CreepySound2;

    public AudioSource pelletAudioSource;
    public AudioClip[] Pellet;
    private AudioClip pelletClip;

    public AudioSource movementAudioSource;
    public AudioClip[] Moving;
    private AudioClip movingClip;


    private CharacterController controller;
    private Vector3 moveDirection;
    public int count;
    public int PelletsCount;

    private float soundCountdown;
    private float defaultSoundCountdown = 0.5f;


    void Start()
    {
        soundCountdown = defaultSoundCountdown;
        controller = GetComponent<CharacterController>();
        count = 0;
        PelletsCount = GameObject.FindGameObjectsWithTag("Pellets").Length;
        SetCountText();
        InvokeRepeating("PlayCreepSound", 2.0f, 20.0f);
        InvokeRepeating("PlayCreepSound2", 15.0f, 20.0f);
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

        soundCountdown -= Time.deltaTime;
        if (Mathf.Abs(moveDirection.x + moveDirection.z) > 0.1f)
        {
            if (soundCountdown <= 0)
            {
                soundCountdown = defaultSoundCountdown;
                randomizeStepSound();
            }
        }
        else
        {
            movementAudioSource.Stop();
        }

        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    private void randomizeStepSound()
    {
        int index = Random.Range(0, Moving.Length);
        movingClip = Moving[index];
        movementAudioSource.clip = movingClip;
        movementAudioSource.Play();
        //Move Sounds*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pellets"))
        {
            other.gameObject.SetActive(false);

            int index = Random.Range(0, Pellet.Length);
            pelletClip = Pellet[index];
            pelletAudioSource.clip = pelletClip;
            pelletAudioSource.Play();

            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = count.ToString()+ "/" + PelletsCount;
        if(count > 0)
        {
            if (count % 30 == 0)
            {
                pelletAudioSource.PlayOneShot(ThirtyCollectibles);
            }
            else if (count % 20 == 0)
            {
                pelletAudioSource.PlayOneShot(TwentyCollectibles);
            }
            else if (count % 10 == 0)
            {
                pelletAudioSource.PlayOneShot(TenCollectibles);
            }
        }
    }
    void PlayCreepSound()
    {
        pelletAudioSource.PlayOneShot(CreepySound);
    }
    void PlayCreepSound2()
    {
        pelletAudioSource.PlayOneShot(CreepySound2);
    }
}

