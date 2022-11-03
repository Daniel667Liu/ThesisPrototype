using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInput : MonoBehaviour
{
    KeyCode key1;
    KeyCode key2;
    
    MoneyActivity activity;

    //state 0, key1 pressed, state 1, key2 pressed
    int state = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        activity = GetComponent<MoneyActivity>();
        //test();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPress();
    }

    public void AssignKeys(KeyCode keyA, KeyCode keyB) 
    {
        key1 = keyA;
        key2 = keyB;

    }

    void CheckPress() 
    {
        
            //return when press 2 keys at the same time
            /*
            if (Input.GetKey(key1) && Input.GetKeyDown(key2))
            {
                return;
            }
            if (Input.GetKeyDown(key1) && Input.GetKey(key2))
            {
                return;
            }
            */

            if (state == 0)
            {
                if (Input.GetKeyDown(key2))
                {
                    //call what to do when press key2
                    //change state to 1
                    activity.SteoTwoEvent();
                    state = 1;
                }
            }

            if (state == 1)
            {
                if (Input.GetKeyDown(key1))
                {
                    //do what to do when press key 1
                    activity.StepOneEvent();
                    state = 0;
                }
            }
        
        
    }

    void test() 
    {
        AssignKeys(KeyCode.LeftArrow, KeyCode.RightArrow);
    }


    
}
