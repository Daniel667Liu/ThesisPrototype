using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public Vector3 iniMousePos;
    
    void Start()
    {
        
    }

    void Update()
    {
        CalculateLines();
    }

    void CalculateLines() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            iniMousePos = Input.mousePosition;
            Debug.Log(iniMousePos);
        }
        if (Input.GetMouseButton(0))
        {
            if ((Input.mousePosition - iniMousePos).magnitude > 100)
            {
                Vector3 newPos = Input.mousePosition;
                Vector3 halfPoint = (iniMousePos + newPos) / 2;
                Vector3 interVec = Input.mousePosition - iniMousePos;
                float angle = Vector3.SignedAngle(interVec, new Vector3(1, 0, 0),new Vector3(0,0,-1));
                Debug.Log(angle);
            }

        }
    }

}
