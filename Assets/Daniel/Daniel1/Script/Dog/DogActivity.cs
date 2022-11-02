using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogActivity : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;

    public GameObject[] nearObjects;//put in sequence: god, band,old man
    public float distanceThreshold = 50f;
    
    public int nearestObject = 0;
    [HideInInspector]
    public bool peopleWalking = false;
    //0:near nothing
    //1:dog
    //2:band
    //3:oldman

    float[] distances;

    AnotherDogActivity anotherDog;
    OldManActivity oldManActivity;
    public Animator band;

    
    
    // Start is called before the first frame update
    void Start()
    {
        distances = new float[3];
        oldManActivity = FindObjectOfType<OldManActivity>();
        anotherDog = FindObjectOfType<AnotherDogActivity>();
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
        DogNearCheck();
    }

    //when there is no other dog, just bark
    public void DogBark() 
    {
        
            animator.SetBool("Bark", true);

            
            switch (nearestObject)
            {
                case 1://near another dog
                anotherDog.Bark();
                    return;
                case 2://near band
                    band.SetTrigger("Bark");
                    return;
                case 3://near old man
                    oldManActivity.Bark();
                    return;
            }
            
        

    }

    public void BarkStop() 
    {
        animator.SetBool("Bark", false);
    }

    //return min distance
    float DistanceCal() 
    {
        for (int i = 0; i < nearObjects.Length; i++) 
        {
            Vector3 pos = nearObjects[i].GetComponent<Transform>().position;
            distances[i] = Vector3.Distance(transform.position, pos);
        }
        float minDistance = distanceThreshold;
        nearestObject = 0;
        for (int i = 0; i < distances.Length; i++)
        {
            if (distances[i] < minDistance)
            {
                minDistance = distances[i];
                nearestObject = i+1;
            }
        }
        Debug.Log("cal");
        return minDistance;
    }

    void DogNearCheck() 
    {
        if (DistanceCal() > distanceThreshold) //there is no object close enough to the dog
        {
            nearestObject = 0;
        }
    }

}
