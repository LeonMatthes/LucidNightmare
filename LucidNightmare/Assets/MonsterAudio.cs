using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAudio : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("randomSound", 5.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void randomSound()
    {
        int index = Random.Range(0, sounds.Length);
        audioSource.clip = sounds[index];
        audioSource.Play();
    }
}
