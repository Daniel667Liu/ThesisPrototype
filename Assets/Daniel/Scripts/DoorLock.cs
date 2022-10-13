using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public Vector2 iniMousePos;
    public List<Vector2> dirs;
    
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
        }
        if (Input.GetMouseButton(0))
        {
            //if the line length is longer than 100, get the dir line
            if (Vector2.Distance(Input.mousePosition,iniMousePos)>100)
            {
                Vector2 pos = Input.mousePosition;
                Vector2 dir = pos - iniMousePos;

                if (dirs.Count == 0) //there is no dir in this list
                {
                    dirs.Add(dir);
                }
                else 
                {
                    //check the angle between this dir and last dir
                    if (Vector2.SignedAngle(dir, dirs[dirs.Count - 1]) > 0 && Vector2.SignedAngle(dir, dirs[dirs.Count - 1]) < 60)
                    {
                        dirs.Add(dir);
                    }
                    //else clear the list and add this dir into list
                    else 
                    {
                        dirs.Clear();
                        dirs.Add(dir);
                    }
                }
                iniMousePos = pos;
                
            }
            if (dirs.Count >= 6) 
            {
                //do what need to open the door
                Debug.Log("open the door");
                dirs.Clear();
            }
        }
        //end the check process and clear the list
        if (Input.GetMouseButtonUp(0)) 
        {
            dirs.Clear();
            iniMousePos = Vector2.zero;
        }
    }

}
