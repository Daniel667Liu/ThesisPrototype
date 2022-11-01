using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPeopleActivity : MonoBehaviour
{
    Animator animator;
    public Animator dogAnimator;
    public Animator peopleAnimator;
    bool isWalking;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustWalkingAnim();
    }

    public void Walk()
    {
        isWalking = true;
    }
    public void StopWalking() 
    {
        isWalking = false;
    }

    void AdjustWalkingAnim() 
    {
        if (isWalking)
        {
            animator.speed = 1f;
            dogAnimator.SetBool("isWalking", true);
            peopleAnimator.SetBool("isWalking", true);
        }
        else 
        {
            animator.speed = 0f;
            dogAnimator.SetBool("isWalking", false);
            peopleAnimator.SetBool("isWalking", false);
        }
    }
}
