using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandInput : MonoBehaviour
{
    private BandActivity activity;

    public KeyCode[] keys = new KeyCode[4];

    private int dir;
    private int prevKey;

    // Start is called before the first frame update
    void Start()
    {
        activity = GetComponent<BandActivity>();
        dir = 1;
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


        // if there is a new key, check if it's next to the prevKey
        if (newKey != -1 && prevKey != -1)
        {
            // reverse if at the ends
            if (prevKey - newKey == dir && (prevKey == 0 || prevKey == 3))
            {
                dir = -dir;
            }
            // play if consecutive
            if (newKey - prevKey == dir)
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
