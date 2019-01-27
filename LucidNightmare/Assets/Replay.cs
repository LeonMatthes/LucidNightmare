using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public AudioClip Clip;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RestartGame", 10.0f, float.PositiveInfinity);
        //GetComponent<AudioSource>().PlayOneShot(Clip);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RestartGame()
    {
        SceneManager.LoadScene("Level");
    }
}
