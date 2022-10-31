using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManActivity : MonoBehaviour
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
            Debug.Log("no animator attached to old man");
        }
        if (TryGetComponent<AudioSource>(out audioSource))
        {
        }
        else
        {
            Debug.Log("no audio source attached to oldman");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrepareFood() 
    {
        //start prepare food
    }

    public void Feed() 
    {
        //seccussfully feed
        //should set a bool in animator, since this func  will be called muti-times
    }


    //call when the dog is near and bark
    public void Bark() 
    {
        animator.SetTrigger("Bark");
    }
}
