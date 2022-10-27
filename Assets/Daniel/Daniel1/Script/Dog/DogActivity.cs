using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogActivity : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent<Animator>(out animator))
        {
        }
        else 
        {
            Debug.Log("no animator attached to the dog");
        }

        if (TryGetComponent<AudioSource>(out audioSource)) 
        {
        }
        else
        {
            Debug.Log("no audio source attached to the dog");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when there is no other dog, just bark
    public void DogBark() 
    {
        
    }


    //when there is other dog, play
    public void DogPlay() 
    {
        
    }
}
