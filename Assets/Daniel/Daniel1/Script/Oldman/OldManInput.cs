using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManInput : MonoBehaviour
{
    public float CD = 1f;
    float waitedTime;
    bool foodPrepared;
    OldManActivity activity;
    // Start is called before the first frame update
    void Start()
    {
        activity = GetComponent<OldManActivity>();   
    }

    // Update is called once per frame
    void Update()
    {
        Wait();
        CheckPress();
    }

    void CheckPress() 
    {
        if (waitedTime >= CD) 
        {
            if (Input.GetMouseButtonDown(2))
            {
                //press the middle button
                //start prepare food
                waitedTime = 0f;
                activity.PrepareFood();
            }

            if (Input.GetMouseButton(2))
            {
                //hold the middle button
                if (Input.mouseScrollDelta.y > 0)
                {
                    //middle mouse scroll up
                    if (foodPrepared)
                    {
                        //successfully trigger the interaction
                        activity.Feed();
                    }

                }
            }


            if (Input.GetMouseButtonUp(2)) 
            {
                //should be set to true in the animation clip prepare
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
