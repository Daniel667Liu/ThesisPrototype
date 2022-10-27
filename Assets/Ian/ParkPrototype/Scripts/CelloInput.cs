using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelloInput : MonoBehaviour
{
    private CelloActivity activity;

    private float accum;
    private int dir; // 0 is left, 1 is right
    private float threshold = 0.5f;

    private float prevMousePos;

    // Start is called before the first frame update
    void Start()
    {
        activity = GetComponent<CelloActivity>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        float dX = mouseX - prevMousePos;
        if (dX > 0)
        {
            if (dir == 1)
            {
                accum += dX;
            }
            else if (dir == 0)
            {
                accum = dX;
                dir = 1;
            }
        }
        else if (dX < 0)
        {
            if (dir == 0)
            {
                accum += dX;
            }
            else if (dir == 1)
            {
                accum = dX;
                dir = 0;
            }
        }


        if (accum > Screen.height / 12f)
        {
            Debug.Log("yes");
            dir = dir == 1 ? 0 : 1;
            activity.PlayActivity();
        }
    }
}
