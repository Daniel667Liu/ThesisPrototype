using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublebassInput : MonoBehaviour
{
    private DoublebassActivity activity;

    private KeyCode[] keys = new KeyCode[4]; // 0 and 1 is left vert, 2 and 3 is right vert, so it should be 01, 23, 01, 23

    private int prevKey;

    // Start is called before the first frame update
    void Start()
    {
        activity = GetComponent<DoublebassActivity>();
        prevKey = -1;
    }

    // Update is called once per frame
    void Update()
    {
        // get the new input key
        int newKey = -1;
        if (Input.GetKeyDown(keys[0]))
        {
            newKey = 0;
        }
        if (Input.GetKeyDown(keys[1]))
        {
            newKey = 1;
        }
        if (Input.GetKeyDown(keys[2]))
        {
            newKey = 2;
        }
        if (Input.GetKeyDown(keys[3]))
        {
            newKey = 3;
        }


        // if there is a new key, check if it's next to the prevKey in group
        if (newKey != -1 && prevKey != -1)
        {
            if (prevKey == 0 && newKey == 1)
            {
                activity.PlayActivity();
            } 
            else if (prevKey == 2 && newKey == 3)
            {
                activity.PlayActivity();
            }
        }


        // update the prevKey
        if (newKey != -1) prevKey = newKey;
    }

    public void AssignKeys(KeyCode key0, KeyCode key1, KeyCode key2, KeyCode key3)
    {
        keys[0] = key0;
        keys[1] = key1;
        keys[2] = key2;
        keys[3] = key3;
    }
}
