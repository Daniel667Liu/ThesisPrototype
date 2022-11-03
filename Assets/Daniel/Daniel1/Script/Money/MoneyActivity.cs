using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyActivity : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    public float speed = 0f;
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
        SpeedDecrease();
        SpeedAdjust();
    }

    void SpeedDecrease() 
    {
        if (speed > 0.1f) 
        {
            speed -= Time.deltaTime * 2f;
        }
    }
    public void StepOneEvent() 
    {
        speed += 1;
        if (speed > 3.5f) 
        {
            speed = 3.5f;
        }
    }

    public void SteoTwoEvent() 
    {
        speed += 1;
        if (speed > 3.5f)
        {
            speed = 3.5f;
        }
    }

    void SpeedAdjust() 
    {
        if (speed > 2f)
        {
            float speedAdjusted = speed - 2f;
            if (speedAdjusted > 1f)
            {
                speedAdjusted = 1f;
            }
            animator.speed = speedAdjusted;
        }
        else 
        {
            animator.speed = 0f;
        }
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
