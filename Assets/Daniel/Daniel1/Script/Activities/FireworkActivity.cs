using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkActivity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //playe the effect of halfway
    public void HalfSuccess() 
    {
        Debug.Log("pressed but didnt hold");
    }


    //play the effect of successful interaction
    public void Success() 
    {
        Debug.Log("pressed and held");
    }

    //play the effect when of start to interact with
    public void StartInteract() 
    {
        Debug.Log("press once");
    }
}
