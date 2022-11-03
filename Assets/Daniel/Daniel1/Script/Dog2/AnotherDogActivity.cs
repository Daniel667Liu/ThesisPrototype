using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherDogActivity : MonoBehaviour
{
    Animator animator;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Bark() 
    {
        animator.SetTrigger("bark");
        audio.PlayOneShot(audio.clip, 2f);
    }
}
