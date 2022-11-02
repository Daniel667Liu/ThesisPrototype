using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPeopleInput : MonoBehaviour
{
    KeyCode key1;
    DogPeopleActivity activity;
    DogActivity dogActivity;
    // Start is called before the first frame update
    void Start()
    {
        //test();
        dogActivity = FindObjectOfType<DogActivity>();
        activity = GetComponent<DogPeopleActivity>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPress();
    }

    public void AssignKeys(KeyCode key) 
    {
        key1 = key;
    }

    void CheckPress() 
    {
        if (Input.GetKey(key1))
        {
            activity.Walk();
            dogActivity.peopleWalking = true;
        }
        else 
        {
            activity.StopWalking();
            dogActivity.peopleWalking = false;
        }
    }

    void test() 
    {
        key1 = KeyCode.L;
    }
}
