using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInput : MonoBehaviour
{
    KeyCode key1;
    KeyCode key2;
    public float stepGap = 0.5f;
    float waitedTime;
    public bool arrivedPoint;
    bool p1;
    bool p2;
    bool ph1;
    bool ph2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignKeys(KeyCode keyA, KeyCode keyB) 
    {
        key1 = keyA;
        key2 = keyB;

        p1 = Input.GetKeyDown(key1);
        p2 = Input.GetKeyDown(key2);
  
    }

    void CheckPress() 
    {
       
    }
}
