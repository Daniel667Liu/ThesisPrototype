using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumsInput : MonoBehaviour
{
    private DrumsActivity activity;

    private KeyCode[] keys = new KeyCode[4];

    // Start is called before the first frame update
    void Start()
    {
        activity = GetComponent<DrumsActivity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keys[0]))
        {
            activity.PlayActivity(0);
        }
        if (Input.GetKeyDown(keys[1]))
        {
            activity.PlayActivity(1);
        }
        if (Input.GetKeyDown(keys[2]))
        {
            activity.PlayActivity(2);
        }
        if (Input.GetKeyDown(keys[3]))
        {
            activity.PlayActivity(3);
        }
    }

    public void AssignKeys(KeyCode key0, KeyCode key1, KeyCode key2, KeyCode key3)
    {
        keys[0] = key0;
        keys[1] = key1;
        keys[2] = key2;
        keys[3] = key3;
    }
}
