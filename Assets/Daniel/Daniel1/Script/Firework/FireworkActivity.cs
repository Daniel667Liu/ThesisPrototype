using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkActivity : MonoBehaviour
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
            Debug.Log("no animator attached to firework");
        }
        if (TryGetComponent<AudioSource>(out audioSource))
        {
        }
        else 
        {
            Debug.Log("no audio source attached to the firework");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //playe the effect of halfway
    public void HalfSuccess() 
    {
        
    }


    //play the effect of successful interaction
    public void Success() 
    {
       
    }

    //play the effect when of start to interact with
    public void StartInteract() 
    {
       
    }
}
