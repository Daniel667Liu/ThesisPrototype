using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject hourHand;
    public GameObject minuteHand;
    bool canControl = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        ClockRun();
        AutoRotate();
    }
    void ClockRun() 
    {

        
        if (canControl) 
        {
            Rigidbody hourRB = hourHand.GetComponent<Rigidbody>();
            Rigidbody minuteRB = minuteHand.GetComponent<Rigidbody>();
            hourRB.AddRelativeTorque(new Vector3(0, 0, -8f*Input.mouseScrollDelta.y*(Mathf.Abs(hourRB.angularVelocity.z)  + 0.02f)), ForceMode.Force);
            minuteRB.AddRelativeTorque(new Vector3(0, 0, -8f * Input.mouseScrollDelta.y * (Mathf.Abs(minuteRB.angularVelocity.z)  + 0.02f)), ForceMode.Force);
        }
        if (minuteHand.GetComponent<Rigidbody>().angularVelocity.z <= -6) 
        {
            canControl = false;
        }
        

    }

   

    void AutoRotate() 
    {
        if (!canControl) 
        {
            Rigidbody hourRB = hourHand.GetComponent<Rigidbody>();
            Rigidbody minuteRB = minuteHand.GetComponent<Rigidbody>();
            hourRB.angularVelocity = new Vector3(0, 0, -0.4f);
            minuteRB.angularVelocity = new Vector3(0, 0, -6.1f);
        }
        
        
    }
}
