using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public bool selected;

    public GameObject hourHand;
    public GameObject minuteHand;
    bool canControl = true;
    private AudioSource audioSource;
    bool soundPlayed;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();

        selected = false;
    }

    void Update()
    {
        if (selected)
        {
            ClockRun();
        }
        AutoRotate();
    }
    void ClockRun() 
    {

        
        if (canControl) 
        {
            Rigidbody hourRB = hourHand.GetComponent<Rigidbody>();
            Rigidbody minuteRB = minuteHand.GetComponent<Rigidbody>();
            hourRB.AddRelativeTorque(new Vector3(0, 0, 8f*Input.mouseScrollDelta.y*(Mathf.Abs(hourRB.angularVelocity.z)  + 0.08f)), ForceMode.Force);
            minuteRB.AddRelativeTorque(new Vector3(0, 0, 8f * Input.mouseScrollDelta.y * (Mathf.Abs(minuteRB.angularVelocity.z)  + 0.08f)), ForceMode.Force);
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
            if (!soundPlayed) 
            {
                audioSource.Play();
                soundPlayed = true;
            }
        }
        
        
    }
}
