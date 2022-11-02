using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) Debug.Log("Y");
        if (Input.GetKeyDown(KeyCode.U)) Debug.Log("U");
        if (Input.GetKeyDown(KeyCode.J)) Debug.Log("J");

        if (Input.anyKeyDown)
        {
            Debug.Log(Input.inputString);
        }
    }
}
