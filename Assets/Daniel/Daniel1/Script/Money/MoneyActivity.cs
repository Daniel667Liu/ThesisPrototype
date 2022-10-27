using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyActivity : MonoBehaviour
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
            Debug.Log("no animator attached to money");
        }

        if (TryGetComponent<AudioSource>(out audioSource))
        {
        }
        else
        {
            Debug.Log("no audio source attached to money");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StepOneEvent() 
    {
        Debug.Log("step1");
    }

    public void SteoTwoEvent() 
    {
        Debug.Log("step2");
    }

    public void ArrivedPoint() 
    {

    }
}
