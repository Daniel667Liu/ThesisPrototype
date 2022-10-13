using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class CurtainControl : MonoBehaviour
{
    private PlayableDirector pd;
    
    
    // Start is called before the first frame update
    void Start()
    {
        pd = GetComponent<PlayableDirector>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DragCurtain();   
    }

    void DragCurtain() 
    {
        pd.time += Input.mouseScrollDelta.y*Time.deltaTime*10;
        if (pd.time < 0) 
        {
            pd.time = 0;
        }
        if (pd.time > 5) 
        {
            pd.time = 5;
        }
    }
}
