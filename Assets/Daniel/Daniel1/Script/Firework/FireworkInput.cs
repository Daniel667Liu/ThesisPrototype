using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkInput : MonoBehaviour
{
    private KeyCode key1;
    public float waitTime = 1f;
    float waitedTime = 0f;
    FireworkActivity activity;
    // Start is called before the first frame update
    void Start()
    {
        //Test();
        //get the activity script, should be on the same object
        activity = GetComponent<FireworkActivity>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPressed();
    }

    //call from ui layer
    public void AssignKeys(KeyCode key) 
    {
        key1 = key;
    }

    void CheckPressed() 
    {
        if (Input.GetKeyDown(key1)) 
        {
            activity.StartInteract();
        }
        if (Input.GetKey(key1)) 
        {
            Wait();
        }
        if (Input.GetKeyUp(key1)) 
        {
            if (waitedTime >= waitTime)
            {
                //pressed and held
                activity.Success();
            }
            else
            {
                //when pressed but not held
                activity.HalfSuccess();
            } 
            //everytime release the key, reset the waited time.
            waitedTime = 0f;
        }
    }

    void Wait() 
    {
        waitedTime += 1f * Time.deltaTime;
    }

    void Test() 
    {
        key1 = KeyCode.M;
    }
}
