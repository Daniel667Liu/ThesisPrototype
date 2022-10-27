using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaxophoneInput : MonoBehaviour
{
    private SaxophoneActivity activity;

    private KeyCode[] keys = new KeyCode[3];

    private int currentState; // 0 means nothing is pressed, 1 means 1 is pressed, 2 means 02 is pressed

    private bool[] keyPressed = new bool[3];


    // Start is called before the first frame update
    void Start()
    {
        activity = GetComponent<SaxophoneActivity>();
    }

    // Update is called once per frame
    void Update()
    {
        // update keyPressed
        if (Input.GetKeyDown(keys[0]))
        {
            keyPressed[0] = true;
            keyPressed[1] = false;
        }
        if (Input.GetKeyUp(keys[0])) keyPressed[0] = false;

        if (Input.GetKeyDown(keys[1]))
        {
            keyPressed[1] = true;
            keyPressed[0] = false;
            keyPressed[2] = false;
        }
        if (Input.GetKeyUp(keys[1])) keyPressed[1] = false;

        if (Input.GetKeyDown(keys[2]))
        {
            keyPressed[2] = true;
            keyPressed[1] = false;
        }
        if (Input.GetKeyUp(keys[2])) keyPressed[2] = false;

        // check if state should change
        int oldState = currentState;
        switch (currentState)
        {
            case 0:
                if (keyPressed[0] && keyPressed[2])
                    currentState = 2;
                else if (keyPressed[1])
                    currentState = 1;
                break;
            case 1:
                if (keyPressed[0] && keyPressed[2])
                    currentState = 2;
                break;
            case 2:
                if (keyPressed[1])
                    currentState = 1;
                break;
        }

        // if state has changed, increase the meter
        if (oldState != currentState)
        {
            activity.PlayActivity();
        }
    }

    public void AssignKeys(KeyCode key0, KeyCode key1, KeyCode key2)
    {
        keys[0] = key0;
        keys[1] = key1;
        keys[2] = key2;
    }
}
