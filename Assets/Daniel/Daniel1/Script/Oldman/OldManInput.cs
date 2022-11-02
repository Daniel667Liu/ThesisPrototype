using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManInput : MonoBehaviour
{
    KeyCode key1;
    KeyCode key2;
    KeyCode key3;
    KeyCode key4;
    public bool key1P;
    public bool key2P;
    public bool key3P;
    public bool key4P;
    public float CD = 5f;
    public float waitedTime;
    bool foodPrepared;
    OldManActivity activity;
    // Start is called before the first frame update
    void Start()
    {
        activity = GetComponent<OldManActivity>();
        AssignKeys(KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4);
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
        BoolSetting();
        Wait();
        CheckPress();
    }
    void BoolSetting() 
    {
        SingleBoolSetting(key1, key1P);
        SingleBoolSetting(key2, key2P);
        SingleBoolSetting(key3, key3P);
        SingleBoolSetting(key4, key4P);
    }

    void SingleBoolSetting(KeyCode key, bool keyBool) 
    {
        if (Input.GetKeyDown(key)) 
        {
            keyBool = true;
        }
        if (Input.GetKeyUp(key)) 
        {
            keyBool = false;
            
        }
    }
    void CheckPress() 
    {
        if (waitedTime >= CD)
        {
            
            if (key1P && key2P && key3P && key4P) //when 4 keys are pressed 
            {
                activity.PrepareFood();
            }
            else 
            {
                if (foodPrepared)
                {
                    activity.Feed();
                    activity.PrepareStop();
                    waitedTime = 0f;
                }
                else 
                {
                    activity.PrepareStop();
                }
                foodPrepared = false;
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
        foodPrepared = true;
    }
}
