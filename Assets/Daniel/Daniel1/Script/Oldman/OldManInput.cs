using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManInput : MonoBehaviour
{
    KeyCode key1;
    KeyCode key2;
    KeyCode key3;
    KeyCode key4;
    bool key1P;
    bool key2P;
    bool key3P;
    bool key4P;
    public float CD = 5f;
    float waitedTime;
    bool foodPrepared;
    bool prepareTriggered =true;
    OldManActivity activity;

    int state = 0; // 0 is idle, 1 is reaching, 2 is ready to feed

    // Start is called before the first frame update
    void Start()
    {
        activity = GetComponent<OldManActivity>();
        //AssignKeys(KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R);
        waitedTime = 6f;
    }

    public void AssignKeys(KeyCode keyA, KeyCode keyB,KeyCode keyC,KeyCode keyD) 
    {
        key1 = keyA;
        key2 = keyB;
        key3 = keyC;
        key4 = keyD;
    }

    // Update is called once per frame
    void Update()
    {
        //BoolSetting();
        //Wait();
        bools();
        
  
    }

    void bools()
    {
        if (Input.GetKeyDown(key1))
        {
            key1P = true;
        }
        if (Input.GetKeyDown(key2))
        {
            key2P = true;
        }
        if (Input.GetKeyDown(key3))
        {
            key3P = true;
        }
        if (Input.GetKeyDown(key4))
        {
            key4P = true;
        }

        if (Input.GetKeyUp(key1))
        {
            key1P = false;
        }
        if (Input.GetKeyUp(key2))
        {
            key2P = false;
        }
        if (Input.GetKeyUp(key3))
        {
            key3P = false;
        }
        if (Input.GetKeyUp(key4))
        {
            key4P = false;
        }

        if (state == 0)
        {
            if (key1P && key2P && key3P && key4P)
            {
                activity.PrepareFood();
                state = 1;
            }
        }
        else if (state == 1)
        {
            if (!(key1P && key2P && key3P && key4P))
            {
                activity.PrepareStop();
                state = 0;
            }
        }
        else if (state == 2)
        {
            if (!(key1P && key2P && key3P && key4P))
            {
                activity.Feed();
                state = 0;
}
        }
    }

    
    void BoolSetting() 
    {
        if (Input.GetKeyDown(key1)) 
        {
            key1P = true;
            CheckPress();
        }
        if (Input.GetKeyDown(key2)) 
        {
            key2P = true;
            CheckPress();
        }
        if (Input.GetKeyDown(key3))
        {
            key3P = true;
            CheckPress();
        }
        if (Input.GetKeyDown(key4))
        {
            key4P = true;
            CheckPress();
        }

        if (Input.GetKeyUp(key1)) 
        {
            key1P = false;
            if (foodPrepared)
            {
                activity.Feed();
                waitedTime = 0f;
                prepareTriggered = true;

            }
            else
            {
                if (!prepareTriggered) 
                {
                    activity.PrepareStop();
                    prepareTriggered = true;
                }
                
            }
            foodPrepared = false;
        }
        if (Input.GetKeyUp(key2))
        {
            key2P = false;
            if (foodPrepared)
            {
                activity.Feed();
                waitedTime = 0f;
                prepareTriggered = true;

            }
            else
            {
                if (!prepareTriggered)
                {
                    activity.PrepareStop();
                    prepareTriggered = true;
                }
            }
            foodPrepared = false;
        }
        if (Input.GetKeyUp(key3))
        {
            key3P = false;
            if (foodPrepared)
            {
                activity.Feed();
                waitedTime = 0f;
                prepareTriggered = true;

            }
            else
            {
                if (!prepareTriggered)
                {
                    activity.PrepareStop();
                    prepareTriggered = true;
                }
            }
            foodPrepared = false;
        }
        if (Input.GetKeyUp(key4))
        {
            key4P = false;
            if (foodPrepared)
            {
                activity.Feed();
                prepareTriggered = true;
                waitedTime = 0f;
            }
            else
            {
                if (!prepareTriggered)
                {
                    activity.PrepareStop();
                    prepareTriggered = true;
                }
            }
            foodPrepared = false;
        }
    }

    
    void CheckPress() 
    {
        if (waitedTime >= CD)
        {
            
            if (key1P && key2P && key3P && key4P) //when 4 keys are pressed 
            {
                activity.PrepareFood();
                prepareTriggered = false;   
         }
            
        }
    }

    void Wait() 
    {
        waitedTime += 1 * Time.deltaTime;
    }

    //should call in animation clip
    public void FoodPrepared() 
    {
        //foodPrepared = true;
        state = 2;
    }
}
