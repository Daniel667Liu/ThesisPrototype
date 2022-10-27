using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInput : MonoBehaviour
{
    KeyCode key1;
    public float CD = 1f;
    float waitedTime;
    public bool nearOtherDog;
    DogActivity activity;
    // Start is called before the first frame update
    void Start()
    {
        test();
        activity = FindObjectOfType<DogActivity>();
    }

    // Update is called once per frame
    void Update()
    {
        Wait();
        CheckPress();
    }

    public void AssignKeys(KeyCode key)
    {
        key1 = key;
    }

    void CheckPress()
    {
        if (Input.GetKeyDown(key1)) 
        {
            if (waitedTime >= CD) 
            {
                waitedTime = 0f;
                if (nearOtherDog)
                {
                    //if is near another dog
                    activity.DogPlay();
                }
                else
                {
                    //if the dog is standing alone
                    activity.DogBark();
                }
            }
            
        }
        
    }

    void Wait() 
    {
        waitedTime += 1f * Time.deltaTime;
    }

    void test() 
    {
        key1 = KeyCode.P;
    }
}
