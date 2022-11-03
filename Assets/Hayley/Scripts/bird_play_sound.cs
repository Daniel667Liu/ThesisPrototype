using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_play_sound : MonoBehaviour
{
    private AudioSource fly;

    // Start is called before the first frame update
    void Start()
    {
        fly = GetComponent<AudioSource>();
    }


    public void PlaySound()
    {
        fly.Play();
    }


}
